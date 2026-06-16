namespace DataAccsessLayer.Abstract.Integrations
{
    public interface IPlcReader : IAsyncDisposable
    {
        Task ReadAndSaveAsync(int machineId, CancellationToken ct = default);
    }
}
