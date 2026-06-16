using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.OilAnalysisReportDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class OilAnalysisReportManager : GenericManager<DB_OilAnalysisReport, OilAnalysisReportDto, CreateOilAnalysisReportDto, UpdateOilAnalysisReportDto>, IOilAnalysisReportService
    {
        private readonly IOilAnalysisReportRepository _repo;
        public OilAnalysisReportManager(IUnitOfWork uow, IMapper mapper, IOilAnalysisReportRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<OilAnalysisReportDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<OilAnalysisReportDto>>(entities);
            return dtos;
        }
    }
}
