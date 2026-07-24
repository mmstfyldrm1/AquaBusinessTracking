using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.IncomingGoodsTrackingDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class IncomingGoodsTrackingManager : GenericManager<DB_IncomingGoodsTracking, IncomingGoodsTrackingDto, CreateIncomingGoodsTrackingDto, UpdateIncomingGoodsTrackingDto>, IIncomingGoodsTrackingService
    {
        private readonly IIncomingGoodsTrackingRepository _repo;
        public IncomingGoodsTrackingManager(IUnitOfWork uow, IMapper mapper, IIncomingGoodsTrackingRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<IncomingGoodsTrackingDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            return _mapper.Map<List<IncomingGoodsTrackingDto>>(entities);
        }
    }
}
