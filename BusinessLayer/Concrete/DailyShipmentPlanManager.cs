using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.DailyShipmentPlanDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DailyShipmentPlanManager : GenericManager<DB_DailyShipmentPlan, DailyShipmentPlanDto, CreateDailyShipmentPlanDto, UpdateDailyShipmentPlanDto>, IDailyShipmentPlanService
    {
        private readonly IDailyShipmentPlanRepository _repo;
        public DailyShipmentPlanManager(IUnitOfWork uow, IMapper mapper, IDailyShipmentPlanRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<DailyShipmentPlanDto>> GetActivePlan()
        {
            var entities = await _repo.GetActivePlan();
            var dtos = _mapper.Map<List<DailyShipmentPlanDto>>(entities);
            return dtos;
        }

        public async Task<List<DailyShipmentPlanDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<DailyShipmentPlanDto>>(entities);
            return dtos;
        }

        public async Task<bool> UpdateIsStatus(int id)
        {
            var result = await _repo.UpdateIsStatus(id);
            return result;
        }
    }
}
