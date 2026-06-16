using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.TestDtos.TestDetailDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TestDetailManager : GenericManager<DB_TestDetail, TestDetailDto, CreateTestDetailDto, UpdateTestDetailDto>, ITestDetailService
    {
        public TestDetailManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
