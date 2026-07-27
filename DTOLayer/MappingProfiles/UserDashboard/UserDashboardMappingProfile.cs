using AutoMapper;
using DTOLayer.Dtos.UserDashboardDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.UserDashboard
{
    public class UserDashboardMappingProfile : Profile
    {
        public UserDashboardMappingProfile()
        {
            CreateMap<DB_FavoriteMenuItem, UserDashboardAddFavoriteModuleDto>().ReverseMap();
        }
    }
}
