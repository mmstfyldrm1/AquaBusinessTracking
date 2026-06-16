using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.PapperMachineChemicalDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PapperMachineChemicalManager : GenericManager<DB_PapperMachineChemical, PapperMachineChemicalDto, CreatePapperMachineChemicalDto, UpdatePapperMachineChemicalDto>, IPapperMachineChemicalService
    {
        private readonly IPapperMachineChemicalRepository _repo;
        public PapperMachineChemicalManager(IUnitOfWork uow, IMapper mapper, IPapperMachineChemicalRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<PapperMachineChemicalDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<PapperMachineChemicalDto>>(entities);
            return dtos;
        }
    }
}
