using AutoMapper;
using DTOLayer.Dtos.PlanningScorBoardViewDto;
using DTOLayer.Dtos.PlanningScorBoardViewDtos;
using DTOLayer.Dtos.SentezAllDataDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Planning
{
    public class PlanningMappingProfile : Profile
    {
        public PlanningMappingProfile()
        {
            #region Planning Score Board

            CreateMap<DB_PlanningScorBoardView, CreatePlanningScorBoardViewDto>().ReverseMap();
            CreateMap<DB_PlanningScorBoardView, UpdatePlanningScorBoardViewDto>().ReverseMap();
            CreateMap<DB_PlanningScorBoardView, PlanningScorBoardViewDto>().ReverseMap();

            CreateMap<DB_PlanningScorBoardView, PlanningScorBoardViewDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Sentez All Data

            CreateMap<DB_SentezAllData, CreateSentezAllDataDto>().ReverseMap();
            CreateMap<DB_SentezAllData, UpdateSentezAllDataDto>().ReverseMap();
            CreateMap<DB_SentezAllData, SentezAllDataDto>().ReverseMap();

            CreateMap<DB_SentezAllData, SentezAllDataDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}