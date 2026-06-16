using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ElectricMotorTrackingManager : GenericManager<DB_ElectricMotorTracking, ElectricMotorDto, CreateElectricMotorDto, UpdateElectricMotorDto>, IElectricMotorTrackingService
    {
        private readonly IElectricMotorTrackingRepository _repo;
        public ElectricMotorTrackingManager(IUnitOfWork uow, IMapper mapper, IElectricMotorTrackingRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<ElectricMotorDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<ElectricMotorDto>>(entities);
            return dtos;
        }
    }
}
