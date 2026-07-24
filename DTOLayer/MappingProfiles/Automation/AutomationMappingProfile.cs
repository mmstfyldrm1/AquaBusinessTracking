using AutoMapper;
using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;
using DTOLayer.Dtos.PlcDtos.PlcTagsDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Automation
{
    public class AutomationMappingProfile : Profile
    {
        public AutomationMappingProfile()
        {
            #region PLC Machine

            CreateMap<DB_PlcMachine, PlcMachineDto>().ReverseMap();
            CreateMap<DB_PlcMachine, CreatePlcMachineDto>().ReverseMap();
            CreateMap<DB_PlcMachine, UpdatePlcMachineDto>().ReverseMap();

            #endregion

            #region PLC Tags

            CreateMap<DB_PlcTags, PlcMachineTagsDto>().ReverseMap();

            CreateMap<DB_PlcTags, CreatePlcMachineTagsDto>()
                .ReverseMap()
                .ForMember(x => x.Machine, opt => opt.Ignore());

            CreateMap<DB_PlcTags, UpdatePlcMachineTagsDto>().ReverseMap();

            CreateMap<DB_PlcTags, PlcMachineTagsDto>()
                .ForMember(x => x.MachineName,
                    x => x.MapFrom(s => s.Machine != null
                        ? s.Machine.Name
                        : null));

            #endregion
        }
    }
}