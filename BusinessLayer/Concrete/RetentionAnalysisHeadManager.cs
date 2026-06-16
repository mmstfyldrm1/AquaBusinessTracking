using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RetentionAnalysisHeadManager : GenericManager<DB_RetentionAnalysisHead, RetentionAnalysisHeadDto, CreateRetentionAnalysisHeadDto, UpdateRetentionAnalysisHeadDto>, IRetentionAnalysisHeadService
    {
        private readonly IRetentionAnalysisHeadRepository _repo;
        public RetentionAnalysisHeadManager(IUnitOfWork uow, IMapper mapper, IRetentionAnalysisHeadRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<RetentionAnalysisHeadDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<RetentionAnalysisHeadDto>>(entities);
            return dtos;
        }
    }
}
