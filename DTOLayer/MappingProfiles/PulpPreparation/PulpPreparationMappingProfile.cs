using AutoMapper;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.PulpPreparation
{
    public class PulpPreparationMappingProfile : Profile
    {
        public PulpPreparationMappingProfile()
        {
            #region Dough Preparation

            CreateMap<DB_DoughPreparation, DoughPreparationDto>().ReverseMap();
            CreateMap<DB_DoughPreparation, CreateDoughPreparationDto>().ReverseMap();
            CreateMap<DB_DoughPreparation, UpdateDoughPreparationDto>().ReverseMap();

            CreateMap<DB_DoughPreparation, DoughPreparationDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Dough Preparation Analysis

            CreateMap<DB_DoughPreparationAnalysisResults, DoughPreparationAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_DoughPreparationAnalysisResults, CreateDoughPreparationAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_DoughPreparationAnalysisResults, UpdateDoughPreparationAnalysisResultsDto>().ReverseMap();

            CreateMap<DB_DoughPreparationAnalysisResults, DoughPreparationAnalysisResultsDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}