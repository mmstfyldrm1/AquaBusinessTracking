using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BasinManager : GenericManager<DB_Basin, BasinDto, CreateBasinDto, UpdateBasinDto>, IBasinService
    {

        private readonly IBasinRepository _basinRepository;
        public BasinManager(IUnitOfWork uow, IMapper mapper, IBasinRepository basinRepository) : base(uow, mapper)
        {
            _basinRepository = basinRepository;
        }

        public async Task<List<BasinDto>> GetWithDetails()
        {
            var data = await _basinRepository.GetBasinsWithDetails();
            return _mapper.Map<List<BasinDto>>(data);
        }
    }
}
