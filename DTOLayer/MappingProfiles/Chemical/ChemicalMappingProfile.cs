using AutoMapper;
using DTOLayer.Dtos.PapperMachineChemicalDtos;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Chemical
{
    public class ChemicalMappingProfile : Profile
    {
        public ChemicalMappingProfile()
        {
            #region Paper Machine Chemical

            CreateMap<DB_PapperMachineChemical, CreatePapperMachineChemicalDto>().ReverseMap();
            CreateMap<DB_PapperMachineChemical, UpdatePapperMachineChemicalDto>().ReverseMap();
            CreateMap<DB_PapperMachineChemical, PapperMachineChemicalDto>().ReverseMap();

            CreateMap<DB_PapperMachineChemical, PapperMachineChemicalDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Water Preparation And Consumption

            CreateMap<DB_WaterPreparationAndConsumption, CreateWaterPreparationAndConsumptionDto>().ReverseMap();
            CreateMap<DB_WaterPreparationAndConsumption, UpdateWaterPreparationAndConsumptionDto>().ReverseMap();
            CreateMap<DB_WaterPreparationAndConsumption, WaterPreparationAndConsumptionDto>().ReverseMap();

            CreateMap<DB_WaterPreparationAndConsumption, WaterPreparationAndConsumptionDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}