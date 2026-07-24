using AutoMapper;
using DTOLayer.Dtos.DepartmentDtos;
using DTOLayer.Dtos.MessageDtos;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.UserDashboardDtos;
using DTOLayer.Dtos.UserDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Common
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            #region Department

            CreateMap<DB_Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<DB_Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<DB_Department, DepartmentDto>().ReverseMap();

            #endregion

            #region Shift

            CreateMap<DB_Shift, CreateShiftDto>().ReverseMap();
            CreateMap<DB_Shift, UpdateShiftDto>().ReverseMap();
            CreateMap<DB_Shift, ShiftDto>().ReverseMap();

            #endregion

            #region Message

            CreateMap<DB_Message, MessageDto>().ReverseMap();
            CreateMap<DB_Message, CreateMessageDto>().ReverseMap();
            CreateMap<DB_Message, UpdateMessageDto>().ReverseMap();

            #endregion

            #region User

            CreateMap<DB_AppUser, UpdateUserDto>()
                .ForMember(x => x.DepartmentName,
                    x => x.MapFrom(s => s.Department != null
                        ? s.Department.DepartmentName
                        : null))
                .ReverseMap();

            #endregion

            #region Favorite Menu

            CreateMap<DB_FavoriteMenuItem, UserDashboardFavoriteMenuDto>().ReverseMap();
            CreateMap<DB_FavoriteMenuItem, UserDashboardAddFavoriteModuleDto>().ReverseMap();

            #endregion
        }
    }
}