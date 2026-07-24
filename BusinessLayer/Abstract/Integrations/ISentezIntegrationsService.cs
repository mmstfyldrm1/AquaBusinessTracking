using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract.Integrations
{
    public interface ISentezIntegrationsService
    {
        public Task<SentezIntegrationsResponsoDto<T>?> ExecuteQueryAsync<T>(string query);

        public Task<SentezUpdateResponseDto?> ExecuteUpdateQueryAsync(string query);
    }
}
