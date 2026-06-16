using BusinessLayer.Abstract.Integrations;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.Integrations;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete.Integrations
{
    public class PlcService : IPlcService
    {
        private readonly IUnitOfWork _uow;

        public PlcService(IUnitOfWork uow) => _uow = uow;
        public async Task<List<PlcReadingDto>> GetLastReadingsAsync(int machineId, int count = 50)
        {
            var tags = (await _uow.Repository<DB_PlcTags>().TGetAll())
                .Where(t => t.MachineId == machineId && t.IsActive)
                .ToList();

            var result = new List<PlcReadingDto>();

            foreach (var tag in tags)
            {
                var lastReading = (await _uow.Repository<DB_PlcReading>().TGetAll())
                    .Where(r => r.PlcTagId == tag.RecId)
                    .OrderByDescending(r => r.ReadingTime)
                    .FirstOrDefault();

                if (lastReading is null) continue;

                result.Add(new PlcReadingDto
                {
                    DisplayName = tag.DisplayName,
                    Group = tag.Group,
                    Unit = tag.Unit,
                    Value = lastReading.Value,
                    ReadingTime = lastReading.ReadingTime
                });
            }

            return result;
        }

        public async Task<List<DB_PlcMachine>> GetActiveMachinesAsync()
            => (await _uow.Repository<DB_PlcMachine>().TGetAll())
                .Where(m => m.IsActive)
                .ToList();
    }
}

