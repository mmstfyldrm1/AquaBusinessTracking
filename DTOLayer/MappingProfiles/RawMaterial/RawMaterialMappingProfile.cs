using AutoMapper;
using DTOLayer.Dtos.RawMaterialIntakesDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.RawMaterial
{
    public class RawMaterialMappingProfile : Profile
    {
        public RawMaterialMappingProfile()
        {
            #region Raw Material Intake

            CreateMap<DB_RawMaterialIntake, CreateRawMaterialIntakesDto>().ReverseMap();
            CreateMap<DB_RawMaterialIntake, UpdateRawMaterialIntakesDto>().ReverseMap();
            CreateMap<DB_RawMaterialIntake, RawMaterialIntakesDto>().ReverseMap();

            CreateMap<DB_RawMaterialIntake, RawMaterialIntakesDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}