using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.MassWasteDtos.MassWasteBalanceDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MassWasteBalanceManager : GenericManager<DB_MassWasteBalance, MassWasteBalanceDto, CreateMassWasteBalanceDto, UpdateMassWasteBalanceDto>, IMassWasteBalanceService
    {
        private readonly IMassWasteBalanceRepository _repo;
        public MassWasteBalanceManager(IUnitOfWork uow, IMapper mapper, IMassWasteBalanceRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<MassWasteBalanceDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<MassWasteBalanceDto>>(entities);
            return dtos;
        }
    }
}
