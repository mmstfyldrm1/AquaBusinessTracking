using AutoMapper;
using DTOLayer.Dtos.DailyShipmentPlanDtos;
using DTOLayer.Dtos.LogisticsTrackingReportDtos;
using DTOLayer.Dtos.SentezNotOrdersDtos;
using DTOLayer.Dtos.VechileFuelLogsDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Warehouse
{
    public class WarehouseMappingProfile : Profile
    {
        public WarehouseMappingProfile()
        {
            #region DailyShipmentPlan

            CreateMap<DB_DailyShipmentPlan, CreateDailyShipmentPlanDto>().ReverseMap();
            CreateMap<DB_DailyShipmentPlan, UpdateDailyShipmentPlanDto>().ReverseMap();
            CreateMap<DB_DailyShipmentPlan, DailyShipmentPlanDto>().ReverseMap();

            CreateMap<DB_DailyShipmentPlan, DailyShipmentPlanDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Logistics Tracking

            CreateMap<DB_LogisticsTrackingReport, CreateLogisticsTrackingReportDto>().ReverseMap();
            CreateMap<DB_LogisticsTrackingReport, UpdateLogisticsTrackingReportDto>().ReverseMap();
            CreateMap<DB_LogisticsTrackingReport, LogisticsTrackingReportDto>().ReverseMap();

            CreateMap<DB_LogisticsTrackingReport, LogisticsTrackingReportDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                 .ForMember(x => x.ShipmentNo,
                    x => x.MapFrom(s => s.DailyShipmentPlan != null ? s.DailyShipmentPlan.ShipmentNo : null));


            #endregion

            #region Vehicle Fuel Logs

            CreateMap<DB_VechileFuelLogs, CreateVechileFuelLogsDto>().ReverseMap();
            CreateMap<DB_VechileFuelLogs, UpdateVechileFuelLogsDto>().ReverseMap();
            CreateMap<DB_VechileFuelLogs, VechileFuelLogsDto>().ReverseMap();

            CreateMap<DB_VechileFuelLogs, VechileFuelLogsDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Sentez Not Order

            CreateMap<DB_SentezNotOrder, CreateSentezNotOrdersDto>().ReverseMap();
            CreateMap<DB_SentezNotOrder, UpdateSentezNotOrdersDto>().ReverseMap();
            CreateMap<DB_SentezNotOrder, SentezNotOrderDto>().ReverseMap();

            CreateMap<DB_SentezNotOrder, SentezNotOrderDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}