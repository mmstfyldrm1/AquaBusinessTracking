using DTOLayer.Dtos.TestDtos.TestDetailDtos;

namespace BusinessLayer.Abstract
{
    public interface ITestDetailService : IGenericService<TestDetailDto, CreateTestDetailDto, UpdateTestDetailDto>
    {
    }
}
