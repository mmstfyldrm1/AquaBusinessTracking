using DTOLayer.Dtos.LabWork;
using DTOLayer.Dtos.LabWorkDtos;

namespace BusinessLayer.Abstract
{
    public interface ILabWorkService : IGenericService<LabWorkDto, CreateLabWorkDto, UpdateLabWorkDto>
    {
        public Task<List<LabWorkDto>> GetWithDetails();
    }
}
