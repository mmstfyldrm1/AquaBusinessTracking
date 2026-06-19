using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.SalesScale;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SalesScaleManager : GenericManager<DB_SalesScale, SalesScaleDto, CreateSalesScaleDto, UpdateSalesScaleDto>, ISalesScaleService
    {
        private readonly ISalesScaleRepository _repo;
        public SalesScaleManager(IUnitOfWork uow, IMapper mapper, ISalesScaleRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<SalesScaleDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<SalesScaleDto>>(entities);
            return dtos;
        }


    }
}
