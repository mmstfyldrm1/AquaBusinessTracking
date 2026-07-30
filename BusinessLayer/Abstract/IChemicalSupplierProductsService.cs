using DTOLayer.Dtos.ChemicalSupplierProductsDtos;

namespace BusinessLayer.Abstract
{
    public interface IChemicalSupplierProductsService : IGenericService<ChemicalSupplierProductsDto, CreateChemicalSupplierProductsDto, UpdateChemicalSupplierProductsDto>
    {

        public Task<List<ChemicalSupplierProductsDto>> GetWithDetails();
    }
}
