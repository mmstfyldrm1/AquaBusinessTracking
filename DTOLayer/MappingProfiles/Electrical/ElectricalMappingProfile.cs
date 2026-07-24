using AutoMapper;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;
using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;
using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Electrical
{
    public class ElectricalMappingProfile : Profile
    {
        public ElectricalMappingProfile()
        {
            #region Electric Shift

            CreateMap<DB_ElectricShiftWork, CreateElectricShiftWorkDto>().ReverseMap();
            CreateMap<DB_ElectricShiftWork, UpdateElectiricShiftWorkDto>().ReverseMap();
            CreateMap<DB_ElectricShiftWork, ElectricShiftWorkDto>().ReverseMap();
            CreateMap<DB_ElectricShiftWork, ElectricShiftWorkDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Electric Motor

            CreateMap<DB_ElectricMotorTracking, CreateElectricMotorDto>().ReverseMap();
            CreateMap<DB_ElectricMotorTracking, UpdateElectricMotorDto>().ReverseMap();
            CreateMap<DB_ElectricMotorTracking, ElectricMotorDto>().ReverseMap();
            CreateMap<DB_ElectricMotorTracking, ElectricMotorDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Electric Meter Location

            CreateMap<DB_ElectricMeterLocation, ElectricMeterLocationDto>().ReverseMap();
            CreateMap<DB_ElectricMeterLocation, UpdateElectricMeterLocationDto>().ReverseMap();
            CreateMap<DB_ElectricMeterLocation, CreateElectricMeterLocationDto>().ReverseMap();
            CreateMap<DB_ElectricMeterLocation, ElectricMeterLocationDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Cumulative Electricity Consumption

            CreateMap<DB_CumulativeElectricityConsumption, CumulativeElectricityConsumptionDto>().ReverseMap();

            CreateMap<DB_CumulativeElectricityConsumption, CreateCumulativeElectricityConsumptionDto>()
                .ReverseMap()
                .ForMember(x => x.ElectricMeterLocation, opt => opt.Ignore());

            CreateMap<DB_CumulativeElectricityConsumption, UpdateCumulativeElectricityConsumptionDto>()
                .ReverseMap()
                .ForMember(x => x.ElectricMeterLocation, opt => opt.Ignore())
                .ForMember(x => x.Department, opt => opt.Ignore());

            CreateMap<DB_CumulativeElectricityConsumption, CumulativeElectricityConsumptionDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                .ForMember(x => x.LocationName,
                    x => x.MapFrom(s => s.ElectricMeterLocation != null
                        ? s.ElectricMeterLocation.LocationName
                        : null));

            #endregion
        }
    }
}