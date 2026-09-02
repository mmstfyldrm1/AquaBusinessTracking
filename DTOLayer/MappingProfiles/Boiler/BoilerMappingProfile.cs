using AutoMapper;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using DTOLayer.Dtos.KazanEnergyConsumptionDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Boiler
{
    public class BoilerMappingProfile : Profile
    {
        public BoilerMappingProfile()
        {
            #region Boiler Chemicals

            CreateMap<DB_KazanChemicalsHead, CreateKazanChemicalsHeadDto>().ReverseMap();
            CreateMap<DB_KazanChemicalsHead, UpdateKazanChemicalsHeadDto>().ReverseMap();
            CreateMap<DB_KazanChemicalsHead, KazanChemicalsHeadDto>().ReverseMap();

            CreateMap<DB_KazanChemicalsHead, KazanChemicalsHeadDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Boiler Steam Feed Water Condensate

            CreateMap<DB_BoilerSteamFeedWaterCondensateData, CreateBoilerSteamFeedWaterCondensateDataDto>().ReverseMap();
            CreateMap<DB_BoilerSteamFeedWaterCondensateData, UpdateBoilerSteamFeedWaterCondensateDataDto>().ReverseMap();
            CreateMap<DB_BoilerSteamFeedWaterCondensateData, BoilerSteamFeedWaterCondensateDataDto>().ReverseMap();

            CreateMap<DB_BoilerSteamFeedWaterCondensateData, BoilerSteamFeedWaterCondensateDataDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Boiler Operation and ChemicalConsumption

            CreateMap<DB_BoilerOperationandChemicalConsumption, CreateBoilerOperationandChemicalConsumptionDto>().ReverseMap();
            CreateMap<DB_BoilerOperationandChemicalConsumption, UpdateBoilerOperationandChemicalConsumptionDto>().ReverseMap();


            CreateMap<DB_BoilerOperationandChemicalConsumption, BoilerOperationandChemicalConsumptionDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                .ForMember(x => x.ConsumptionPlace,
                    x => x.MapFrom(s => s.KazanEnergyConsumption != null ? s.KazanEnergyConsumption.ConsumptionPlace : null))
                .ForMember(x => x.ScalePlaceName,
                    x => x.MapFrom(s => s.ScalePlace != null ? s.ScalePlace.DepartmentName : null))
                 .ForMember(x => x.DepartmentName,
                    x => x.MapFrom(s => s.Department != null ? s.Department.DepartmentName : null))




            ;

            #endregion

            #region Kazan Energy Consumption

            CreateMap<DB_KazanEnergyConsumption, CreateKazanEnergyConsumptionDto>().ReverseMap();
            CreateMap<DB_KazanEnergyConsumption, UpdateKazanEnergyConsumptionDto>().ReverseMap();
            CreateMap<DB_KazanEnergyConsumption, KazanEnergyConsumptionDto>().ReverseMap();

            CreateMap<DB_KazanEnergyConsumption, KazanEnergyConsumptionDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                ;

            #endregion

            #region Natural Gas Meter Monitoring

            CreateMap<DB_NaturelGasMeterMonitoring, CreateNaturelGasMeterMonitoringDto>().ReverseMap();
            CreateMap<DB_NaturelGasMeterMonitoring, UpdateNaturelGasMeterMonitoringDto>().ReverseMap();
            CreateMap<DB_NaturelGasMeterMonitoring, NaturelGasMeterMonitoringDto>().ReverseMap();

            CreateMap<DB_NaturelGasMeterMonitoring, NaturelGasMeterMonitoringDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}