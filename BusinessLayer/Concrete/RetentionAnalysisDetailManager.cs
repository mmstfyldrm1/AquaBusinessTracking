using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisDetailDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RetentionAnalysisDetailManager : GenericManager<DB_RetantionAnalysisDetail, RetentionAnalysisDetailDto, CreateRetentionAnalysisDetailDto, UpdateRetentionAnalysisDetailDto>, IRetentionAnalysisDetailService
    {
        public RetentionAnalysisDetailManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
