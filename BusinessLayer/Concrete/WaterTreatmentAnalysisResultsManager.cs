using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WaterTreatmentAnalysisResultsManager : GenericManager<DB_WaterTreatmentAnalysisResults, WaterTreatmentAnalysisResultsDto, CreateWaterTreatmentAnalysisResultsDto, UpdateWaterTreatmentAnalysisResultsDto>, IWaterTreatmentAnalysisResultsService
    {
        private readonly IWaterTreatmentAnalysisResultsRepository _repo;
        public WaterTreatmentAnalysisResultsManager(IUnitOfWork uow, IMapper mapper, IWaterTreatmentAnalysisResultsRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WaterTreatmentAnalysisResultsDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WaterTreatmentAnalysisResultsDto>>(entities);
            return dtos;
        }
    }
}
