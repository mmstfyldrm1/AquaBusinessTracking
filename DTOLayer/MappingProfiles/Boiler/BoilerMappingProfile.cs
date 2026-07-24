using AutoMapper;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
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

            #region Boiler Room Daily Shift Monitoring

            CreateMap<DB_BoilerRoomDailyShiftMonitoring, CreateBoilerRoomDailyShiftMonitoringDto>().ReverseMap();
            CreateMap<DB_BoilerRoomDailyShiftMonitoring, UpdateBoilerRoomDailyShiftMonitoringDto>().ReverseMap();
            CreateMap<DB_BoilerRoomDailyShiftMonitoring, BoilerRoomDailyShiftMonitoringDto>().ReverseMap();

            CreateMap<DB_BoilerRoomDailyShiftMonitoring, BoilerRoomDailyShiftMonitoringDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

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