using DTOLayer.Dtos.MassWasteDtos.MassWasteSupplierDtos;

namespace BusinessLayer.Abstract
{
    public interface IMassWasteSupplierService : IGenericService<MassWasteSupplierDto, CreateMassWasteSupplierDto, UpdateMassWasteSupplierDto>
    {
        public Task<List<MassWasteSupplierDto>> GetWithDetails();
    }
}
