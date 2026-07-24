using AutoMapper;
using DTOLayer.Dtos.WinderCoilLengthControlDto;
using DTOLayer.Dtos.WinderCoilTrackingDto;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Winder
{
    public class WinderMappingProfile : Profile
    {
        public WinderMappingProfile()
        {
            #region Winder Coil Tracking

            CreateMap<DB_WinderCoilTracking, CreateWinderCoilTrackingDto>().ReverseMap();
            CreateMap<DB_WinderCoilTracking, UpdateWinderCoilTrackingDto>().ReverseMap();
            CreateMap<DB_WinderCoilTracking, WinderCoilTrackingDto>().ReverseMap();

            CreateMap<DB_WinderCoilTracking, WinderCoilTrackingDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Winder Coil Length Control

            CreateMap<DB_WinderCoilLengthControl, CreateWinderLengthControlDto>().ReverseMap();
            CreateMap<DB_WinderCoilLengthControl, UpdateWinderCoilLengthControlDto>().ReverseMap();
            CreateMap<DB_WinderCoilLengthControl, WinderCoilLengthControlDto>().ReverseMap();

            CreateMap<DB_WinderCoilLengthControl, WinderCoilLengthControlDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}