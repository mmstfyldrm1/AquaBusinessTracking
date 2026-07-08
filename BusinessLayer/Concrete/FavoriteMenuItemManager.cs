using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.UserDashboardDtos;

namespace BusinessLayer.Concrete
{
    public class FavoriteMenuItemManager : IFavoriteMenuItemService
    {
        private readonly IFavoriteMenuItemRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FavoriteMenuItemManager(IFavoriteMenuItemRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<bool> AddFavorite(UserDashboardAddFavoriteModuleDto dto)
        {
            var resut = await _repository.AddFavorite(dto);
            await _uow.SaveChangesAsync();
            return resut;
        }

        public async Task<List<UserDashboardFavoriteMenuDto>> GetFavoriteMenuItemsByUserIdAsync(int userId)
        {
            var data = await _repository.GetFavoriteMenuItemsByUserIdAsync(userId);
            return _mapper.Map<List<UserDashboardFavoriteMenuDto>>(data);
        }
    }
}
