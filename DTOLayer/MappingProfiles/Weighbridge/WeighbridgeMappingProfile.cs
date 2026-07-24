using AutoMapper;
using DTOLayer.Dtos.IncomingGoodsTrackingDtos;
using DTOLayer.Dtos.SalesScale;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Weighbridge
{
    public class WeighbridgeMappingProfile : Profile
    {
        public WeighbridgeMappingProfile()
        {
            #region Sales Scale

            CreateMap<DB_SalesScale, CreateSalesScaleDto>().ReverseMap();
            CreateMap<DB_SalesScale, UpdateSalesScaleDto>().ReverseMap();
            CreateMap<DB_SalesScale, SalesScaleDto>().ReverseMap();

            CreateMap<DB_SalesScale, SalesScaleDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Incoming Goods Tracking

            CreateMap<DB_IncomingGoodsTracking, CreateIncomingGoodsTrackingDto>().ReverseMap();
            CreateMap<DB_IncomingGoodsTracking, UpdateIncomingGoodsTrackingDto>().ReverseMap();
            CreateMap<DB_IncomingGoodsTracking, IncomingGoodsTrackingDto>().ReverseMap();

            CreateMap<DB_IncomingGoodsTracking, IncomingGoodsTrackingDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}