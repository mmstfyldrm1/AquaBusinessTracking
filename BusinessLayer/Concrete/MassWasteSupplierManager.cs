using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.MassWasteDtos.MassWasteSupplierDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MassWasteSupplierManager : GenericManager<DB_MassWasteSupplier, MassWasteSupplierDto, CreateMassWasteSupplierDto, UpdateMassWasteSupplierDto>, IMassWasteSupplierService
    {
        private readonly IMassWasteSupplierRepository _repo;
        public MassWasteSupplierManager(IUnitOfWork uow, IMapper mapper, IMassWasteSupplierRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<MassWasteSupplierDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<MassWasteSupplierDto>>(entities);
            return dtos;
        }
    }
}
