using AutoMapper;
using DTOLayer.Dtos.MachineStopDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.WetEnd
{
    public class WetEndMappingProfile : Profile
    {
        public WetEndMappingProfile()
        {
            #region Machine Stop

            CreateMap<DB_MachineStop, CreateMachineStopDto>().ReverseMap();
            CreateMap<DB_MachineStop, UpdateMachineStopDto>().ReverseMap();
            CreateMap<DB_MachineStop, MachineStopDto>().ReverseMap();

            CreateMap<DB_MachineStop, MachineStopDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}