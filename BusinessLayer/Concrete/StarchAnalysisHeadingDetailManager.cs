using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class StarchAnalysisHeadingDetailManager : GenericManager<DB_StarchAnalysisHeadingDetail, StarchAnalysisHeadingDetailDto, CreateStarchAnalysisHeadingDetailDto, UpdateStarchAnalysisHeadingDetailDto>, IStarchAnalysisHeadingDetailService
    {
        public StarchAnalysisHeadingDetailManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
