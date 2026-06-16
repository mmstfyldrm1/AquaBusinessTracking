using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.LogisticsTrackingReportDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class LogisticsTrackingReportManager : GenericManager<DB_LogisticsTrackingReport, LogisticsTrackingReportDto, CreateLogisticsTrackingReportDto, UpdateLogisticsTrackingReportDto>, ILogisticsTrackingReportService
    {
        private readonly ILogisticsTrackingReportRepository _repo;
        public LogisticsTrackingReportManager(IUnitOfWork uow, IMapper mapper, ILogisticsTrackingReportRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<LogisticsTrackingReportDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<LogisticsTrackingReportDto>>(entities);
            return dtos;
        }
    }
}
