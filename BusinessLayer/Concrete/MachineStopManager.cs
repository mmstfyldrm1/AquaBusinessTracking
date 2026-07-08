using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.MachineStopDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MachineStopManager : GenericManager<DB_MachineStop, MachineStopDto, CreateMachineStopDto, UpdateMachineStopDto>, IMachineStopService
    {
        private readonly IMachineStopRepository _repo;
        public MachineStopManager(IUnitOfWork uow, IMapper mapper, IMachineStopRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<MachineStopDto>> GetWithDetails()
        {
            var result = await _repo.GetWithDetails();
            var dto = _mapper.Map<List<MachineStopDto>>(result);
            return (dto);
        }

        public async Task<List<StopChartDto>> GetStopChart()
        {
            var result = await _repo.GetStopChart();
            return (result);
        }
    }
}
