using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BufferAnalysisReportManager : GenericManager<DB_BufferAnalysisReport, BufferAnalysisReportDto, CreateBufferAnalysisReportDto, UpdateBufferAnalysisReportDto>, IBufferAnalysisReportService
    {
        private readonly IBufferAnalysisReportRepository _repo;
        public BufferAnalysisReportManager(IUnitOfWork uow, IMapper mapper, IBufferAnalysisReportRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<BufferAnalysisReportDto>> GetPreviousDay()
        {
            var entity = await _repo.GetPreviousDay();
            return _mapper.Map<List<BufferAnalysisReportDto>>(entity);
        }

        public async Task<BufferAnalysisReportDto> GetWithDetails()
        {
            var entity = await _repo.GetWithDetails();
            return _mapper.Map<BufferAnalysisReportDto>(entity);
        }
    }
}
