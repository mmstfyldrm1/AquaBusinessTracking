using DTOLayer.Dtos.PapperMachineChemicalDtos;

namespace BusinessLayer.Abstract
{
    public interface IPapperMachineChemicalService : IGenericService<PapperMachineChemicalDto, CreatePapperMachineChemicalDto, UpdatePapperMachineChemicalDto>
    {
        public Task<List<PapperMachineChemicalDto>> GetWithDetails();
    }
}
