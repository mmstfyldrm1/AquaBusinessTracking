using DTOLayer.Dtos.MassWasteDtos.MassWasteBalanceDtos;

namespace BusinessLayer.Abstract
{
    public interface IMassWasteBalanceService : IGenericService<MassWasteBalanceDto, CreateMassWasteBalanceDto, UpdateMassWasteBalanceDto>
    {
        public Task<List<MassWasteBalanceDto>> GetWithDetails();
    }
}
