using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WinderCoilTrackingDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WinderCoilTrackingManager : GenericManager<DB_WinderCoilTracking, WinderCoilTrackingDto, CreateWinderCoilTrackingDto, UpdateWinderCoilTrackingDto>, IWinderCoilTrackingService
    {
        private readonly IWinderCoilTrackingRepository _repo;
        public WinderCoilTrackingManager(IUnitOfWork uow, IMapper mapper, IWinderCoilTrackingRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WinderCoilTrackingDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WinderCoilTrackingDto>>(entities);
            return dtos;
        }
    }
}
