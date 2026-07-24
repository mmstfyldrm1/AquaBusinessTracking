using AutoMapper;
using DTOLayer.Dtos.WastePaperControlDtos;
using DTOLayer.Dtos.WastePaperCost;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Purchasing
{
    public class PurchasingMappingProfile : Profile
    {
        public PurchasingMappingProfile()
        {
            #region Waste Paper Control

            CreateMap<DB_WastePaperControl, CreateWastePaperControlDto>().ReverseMap();
            CreateMap<DB_WastePaperControl, UpdateWastePaperControlDto>().ReverseMap();
            CreateMap<DB_WastePaperControl, WastePaperControlDto>().ReverseMap();

            CreateMap<DB_WastePaperControl, WastePaperControlDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Waste Paper Cost

            CreateMap<DB_WastePaperCost, CreateWastePaperCostDto>().ReverseMap();
            CreateMap<DB_WastePaperCost, UpdateWastePaperCostDto>().ReverseMap();
            CreateMap<DB_WastePaperCost, WastePaperCostDto>().ReverseMap();

            CreateMap<DB_WastePaperCost, WastePaperCostDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}