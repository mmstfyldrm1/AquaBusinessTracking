using AutoMapper;
using DTOLayer.Dtos.BufferProductionDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.DryEnd
{
    public class DryEndMappingProfile : Profile
    {
        public DryEndMappingProfile()
        {
            #region Buffer Production

            CreateMap<DB_BufferProduction, CreateBufferProductionDto>().ReverseMap();
            CreateMap<DB_BufferProduction, UpdateBufferProductionDto>().ReverseMap();
            CreateMap<DB_BufferProduction, BufferProductionDto>().ReverseMap();

            CreateMap<DB_BufferProduction, BufferProductionDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                .ForMember(x => x.ShiftSupervisorUser,
                    x => x.MapFrom(s => s.ShiftSupervisorUser != null
                        ? s.ShiftSupervisorUser.UserName
                        : null));

            #endregion
        }
    }
}