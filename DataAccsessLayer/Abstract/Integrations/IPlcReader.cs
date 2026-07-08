namespace DataAccsessLayer.Abstract.Integrations
{
    public interface IPlcReader : IAsyncDisposable
    {
        Task ReadAndSaveAsync(int machineId, CancellationToken ct = default);

        Task WriteHeartbeatAsync(int machineId, int maxValue = 10000, CancellationToken ct = default);

    }
}
