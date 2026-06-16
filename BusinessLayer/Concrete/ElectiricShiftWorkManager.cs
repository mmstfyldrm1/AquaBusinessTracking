using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ElectiricShiftWorkManager : GenericManager<DB_ElectricShiftWork, ElectricShiftWorkDto, CreateElectricShiftWorkDto, UpdateElectiricShiftWorkDto>, IElectiricShiftWorkService
    {
        private readonly IElectricShiftWorkRepository _repo;
        public ElectiricShiftWorkManager(IUnitOfWork uow, IMapper mapper, IElectricShiftWorkRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<ElectricShiftWorkDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<ElectricShiftWorkDto>>(entities);
            return dtos;
        }
    }
}
