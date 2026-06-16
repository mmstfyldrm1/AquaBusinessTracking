using DTOLayer.Dtos.WarehouseRequestWaitDtos;

namespace BusinessLayer.Abstract
{
    public interface IWarehouseRequestWaitService : IGenericService<WarehouseRequestWaitDto, CreateWarehouseRequestWaitDto, UpdateWarehouseRequestWaitDto>
    {
        public Task<List<WarehouseRequestWaitDto>> GetWithDetails();
    }
}
