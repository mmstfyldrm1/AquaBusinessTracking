using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class StarchAnalysisHeadingManager : GenericManager<DB_StarchAnalysisHeading, StarchAnalysisHeadingDto, CreateStarchAnalysisHeadingDto, UpdateStarchAnalysisHeadingDto>, IStarchAnalysisHeadingService
    {
        private readonly IStarchAnalysisHeadingRepository _repo;
        public StarchAnalysisHeadingManager(IUnitOfWork uow, IMapper mapper, IStarchAnalysisHeadingRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<StarchAnalysisHeadingDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<StarchAnalysisHeadingDto>>(entities);
            return dtos;
        }
    }
}
