using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.TestDtos.TestHeadDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TestHeadManager : GenericManager<DB_TestHeader, TestHeadDto, CreateTestHeadDto, UpdateTestHeadDto>, ITestHeadService
    {
        private readonly ITestHeadRepository _repo;
        public TestHeadManager(IUnitOfWork uow, IMapper mapper, ITestHeadRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<TestHeadDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<TestHeadDto>>(entities);
            return dtos;
        }
    }
}
