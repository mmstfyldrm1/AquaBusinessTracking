using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ShipmentOrderPlan;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ShipmentOrderPlanManager : GenericManager<DB_ShipmentOrderPlan, ShipmentOrderPlanDto, CreateShipmentOrderPlanDto, UpdateShipmentOrderPlanDto>, IShipmentOrderPlanService
    {
        private readonly IShipmentOrderPlanRepository _shipmentOrderPlanRepository;
        public ShipmentOrderPlanManager(IUnitOfWork uow, IMapper mapper, IShipmentOrderPlanRepository shipmentOrderPlanRepository) : base(uow, mapper)
        {
            _shipmentOrderPlanRepository = shipmentOrderPlanRepository;
        }

        public async Task<List<ShipmentOrderPlanDto>> GetWithDetails()
        {
            var entities = await _shipmentOrderPlanRepository.GetWithDetails();
            var dtos = _mapper.Map<List<ShipmentOrderPlanDto>>(entities);
            return dtos;
        }
    }
}
