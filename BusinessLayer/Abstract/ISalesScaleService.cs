using DTOLayer.Dtos.SalesScale;

namespace BusinessLayer.Abstract
{
    public interface ISalesScaleService : IGenericService<SalesScaleDto, CreateSalesScaleDto, UpdateSalesScaleDto>
    {
        public Task<List<SalesScaleDto>> GetWithDetails();
    }
}
