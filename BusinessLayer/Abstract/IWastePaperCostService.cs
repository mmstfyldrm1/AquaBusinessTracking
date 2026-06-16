using DTOLayer.Dtos.WastePaperCost;

namespace BusinessLayer.Abstract
{
    public interface IWastePaperCostService : IGenericService<WastePaperCostDto, CreateWastePaperCostDto, UpdateWastePaperCostDto>
    {
        public Task<List<WastePaperCostDto>> GetWithDetails();
    }
}
