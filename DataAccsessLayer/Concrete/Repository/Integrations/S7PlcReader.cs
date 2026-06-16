using DataAccsessLayer.Abstract.Integrations;
using DataAccsessLayer.Concrete.UoW;
using EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using S7.Net;


namespace DataAccsessLayer.Concrete.Repository.Integrations
{
    public class S7PlcReader : IPlcReader, IAsyncDisposable
    {
        private readonly Dictionary<int, Plc> _connections = new();
        private readonly IServiceScopeFactory _scopeFactory;

        public S7PlcReader(IServiceScopeFactory scopeFactory)
          => _scopeFactory = scopeFactory;
        public async ValueTask DisposeAsync()
        {
            foreach (var plc in _connections.Values)
            {
                if (plc.IsConnected) plc.Close();
                ((IDisposable)plc).Dispose();
            }
            await ValueTask.CompletedTask;
        }

        public async Task ReadAndSaveAsync(int machineId, CancellationToken ct = default)
        {
            using var scope = _scopeFactory.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            // Makine + tagları çek — Generic repository ile
            var machine = await uow.Repository<DB_PlcMachine>().TGetById(machineId);

            if (machine is null) return;

            var tags = (await uow.Repository<DB_PlcTags>().TGetAll()).Where(t => t.MachineId == machineId && t.IsActive).ToList();




            var plc = GetOrCreateConnection(machine);
            if (!plc.IsConnected)
                await plc.OpenAsync(ct);

            var dataItems = tags.Select(BuildDataItem).ToList();
            await plc.ReadMultipleVarsAsync(dataItems);

            var now = System.DateTime.UtcNow;

            foreach (var (tag, item) in tags.Zip(dataItems))
            {
                await uow.Repository<DB_PlcReading>().TAdd(new DB_PlcReading
                {
                    PlcTagId = tag.RecId,
                    Value = Convert.ToDouble(item.Value),
                    ReadingTime = now
                });
            }

            await uow.SaveChangesAsync();
        }

        private Plc GetOrCreateConnection(DB_PlcMachine machine)
        {
            if (!_connections.TryGetValue(machine.RecId, out var plc))
            {
                plc = new Plc(
                    Enum.Parse<CpuType>(machine.CpuType),
                    machine.IpAddress,
                    (short)machine.Rack,
                    (short)machine.Slot
                );
                _connections[machine.RecId] = plc;
            }
            return plc;
        }

        private static S7.Net.Types.DataItem BuildDataItem(DB_PlcTags tag)
        {
            var varType = tag.DataType switch
            {
                "Real" => VarType.Real,
                "Word" => VarType.Word,
                "Bit" => VarType.Bit,
                "Byte" => VarType.Byte,
                _ => VarType.Real
            };

            // "DB1.DBD0" veya "DB1.DBX8.0" formatını parse et
            var parts = tag.DataAddress.Replace("DB", "").Split('.');
            var db = int.Parse(parts[0]);
            var byteOff = int.Parse(
                System.Text.RegularExpressions.Regex.Replace(parts[1], "[^0-9]", ""));

            // Bit adresi varsa → "DB1.DBX8.0" → parts[2] = "0"
            byte bitAdr = 0;
            if (parts.Length > 2)
                bitAdr = byte.Parse(parts[2]);

            return new S7.Net.Types.DataItem
            {
                DataType = DataType.DataBlock,
                DB = db,
                StartByteAdr = byteOff,
                VarType = varType,
                Count = 1,
                BitAdr = bitAdr
            };
        }


    }
}
