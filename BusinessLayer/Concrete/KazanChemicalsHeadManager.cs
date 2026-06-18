using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class KazanChemicalsHeadManager : GenericManager<DB_KazanChemicalsHead, KazanChemicalsHeadDto, CreateKazanChemicalsHeadDto, UpdateKazanChemicalsHeadDto>, IKazanChemicalsHeadService
    {
        private readonly IKazanChemicalsHeadRepository _repo;
        public KazanChemicalsHeadManager(IUnitOfWork uow, IMapper mapper, IKazanChemicalsHeadRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<KazanChemicalsHeadDto>> GetPreviousDay()
        {
            var entities = await _repo.GetPreviousDay();
            var dtos = _mapper.Map<List<KazanChemicalsHeadDto>>(entities);
            return dtos;
        }

        public async Task<List<KazanChemicalsHeadDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<KazanChemicalsHeadDto>>(entities);
            return dtos;
        }
    }
}
