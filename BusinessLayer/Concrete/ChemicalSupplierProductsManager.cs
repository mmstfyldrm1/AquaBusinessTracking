using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ChemicalSupplierProductsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ChemicalSupplierProductsManager : GenericManager<DB_ChemicalSupplierProducts, ChemicalSupplierProductsDto, CreateChemicalSupplierProductsDto, UpdateChemicalSupplierProductsDto>, IChemicalSupplierProductsService
    {
        private readonly IChemicalSupplierProductsRepository _repo;
        public ChemicalSupplierProductsManager(IUnitOfWork uow, IMapper mapper, IChemicalSupplierProductsRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<ChemicalSupplierProductsDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            return _mapper.Map<List<ChemicalSupplierProductsDto>>(entities);
        }
    }
}
