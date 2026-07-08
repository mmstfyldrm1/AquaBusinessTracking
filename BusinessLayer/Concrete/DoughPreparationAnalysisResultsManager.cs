using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DoughPreparationAnalysisResultsManager : GenericManager<DB_DoughPreparationAnalysisResults, DoughPreparationAnalysisResultsDto, CreateDoughPreparationAnalysisResultsDto, UpdateDoughPreparationAnalysisResultsDto>, IDoughPreparationAnalysisResultsDetailService
    {
        private readonly IDoughPreparationAnalysisResultsRepository _repo;
        public DoughPreparationAnalysisResultsManager(IUnitOfWork uow, IMapper mapper, IDoughPreparationAnalysisResultsRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<DoughPreparationAnalysisResultsDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<DoughPreparationAnalysisResultsDto>>(entities);
            return dtos;
        }
    }
}
