using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;

namespace BusinessLayer.Abstract
{
    public interface IElectiricShiftWorkService : IGenericService<ElectricShiftWorkDto, CreateElectricShiftWorkDto, UpdateElectiricShiftWorkDto>
    {
        public Task<List<ElectricShiftWorkDto>> GetWithDetails();
    }
}
