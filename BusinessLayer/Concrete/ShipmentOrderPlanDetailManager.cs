using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ShipmentOrderPlanDtos.ShipmentOrderPlanDetailDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ShipmentOrderPlanDetailManager : GenericManager<DB_ShipmentOrderPlanDetail, ShipmentOrderPlanDetailDto, CreateShipmentOrderPlanDetailDto, UpdateShipmentOrderPlanDetailDto>, IShipmentOrderPlanDetailService
    {
        private readonly IShipmentOrderPlanDetailRepository _shipmentOrderPlanDetailRepository;
        public ShipmentOrderPlanDetailManager(IUnitOfWork uow, IMapper mapper, IShipmentOrderPlanDetailRepository shipmentOrderPlanDetailRepository) : base(uow, mapper)
        {
            _shipmentOrderPlanDetailRepository = shipmentOrderPlanDetailRepository;
        }

        public async Task<List<ShipmentOrderPlanDetailDto>> GetByShipmentOrderPlanId(int shipmentOrderPlanId)
        {
            var entities = await _shipmentOrderPlanDetailRepository.GetByShipmentOrderPlanId(shipmentOrderPlanId);
            return _mapper.Map<List<ShipmentOrderPlanDetailDto>>(entities);
        }
    }
}
