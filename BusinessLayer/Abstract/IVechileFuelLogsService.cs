using DTOLayer.Dtos.VechileFuelLogsDtos;

namespace BusinessLayer.Abstract
{
    public interface IVechileFuelLogsService : IGenericService<VechileFuelLogsDto, CreateVechileFuelLogsDto, UpdateVechileFuelLogsDto>
    {
        public Task<List<VechileFuelLogsDto>> GetWithDetails();
    }
}
