using DTOLayer.Dtos.TestDtos.TestHeadDtos;

namespace BusinessLayer.Abstract
{
    public interface ITestHeadService : IGenericService<TestHeadDto, CreateTestHeadDto, UpdateTestHeadDto>
    {
        public Task<List<TestHeadDto>> GetWithDetails();
    }
}
