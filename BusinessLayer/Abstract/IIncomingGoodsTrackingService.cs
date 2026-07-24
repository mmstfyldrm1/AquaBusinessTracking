using DTOLayer.Dtos.IncomingGoodsTrackingDtos;

namespace BusinessLayer.Abstract
{
    public interface IIncomingGoodsTrackingService : IGenericService<IncomingGoodsTrackingDto, CreateIncomingGoodsTrackingDto, UpdateIncomingGoodsTrackingDto>
    {
        public Task<List<IncomingGoodsTrackingDto>> GetWithDetails();
    }
}
