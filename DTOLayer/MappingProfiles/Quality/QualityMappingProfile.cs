using AutoMapper;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using DTOLayer.Dtos.BufferGramajProfile;
using DTOLayer.Dtos.BufferGramajProfileDtos;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidity;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidityDtos;
using DTOLayer.Dtos.LabWork;
using DTOLayer.Dtos.LabWorkDtos;
using DTOLayer.Dtos.OilAnalysisReportDtos;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisDetailDtos;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDtos;
using DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.Quality
{
    public class QualityMappingProfile : Profile
    {
        public QualityMappingProfile()
        {
            #region Buffer Analysis Report

            CreateMap<DB_BufferAnalysisReport, CreateBufferAnalysisReportDto>().ReverseMap();
            CreateMap<DB_BufferAnalysisReport, UpdateBufferAnalysisReportDto>().ReverseMap();
            CreateMap<DB_BufferAnalysisReport, BufferAnalysisReportDto>().ReverseMap();

            CreateMap<DB_BufferAnalysisReport, BufferAnalysisReportDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Buffer Grammage Profile

            CreateMap<DB_BufferGramajProfile, CreateBufferGramajProfileDto>().ReverseMap();
            CreateMap<DB_BufferGramajProfile, UpdateBufferGramajProfileDto>().ReverseMap();
            CreateMap<DB_BufferGramajProfile, BufferGramajProfileDto>().ReverseMap();

            CreateMap<DB_BufferGramajProfile, BufferGramajProfileDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Lab Work

            CreateMap<DB_LabWork, CreateLabWorkDto>().ReverseMap();
            CreateMap<DB_LabWork, UpdateLabWorkDto>().ReverseMap();
            CreateMap<DB_LabWork, LabWorkDto>().ReverseMap();

            CreateMap<DB_LabWork, LabWorkDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Oil Analysis Report

            CreateMap<DB_OilAnalysisReport, CreateOilAnalysisReportDto>().ReverseMap();
            CreateMap<DB_OilAnalysisReport, UpdateOilAnalysisReportDto>().ReverseMap();
            CreateMap<DB_OilAnalysisReport, OilAnalysisReportDto>().ReverseMap();

            CreateMap<DB_OilAnalysisReport, OilAnalysisReportDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Starch Analysis

            CreateMap<DB_StarchAnalysisHeading, CreateStarchAnalysisHeadingDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeading, UpdateStarchAnalysisHeadingDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeading, StarchAnalysisHeadingDto>().ReverseMap();

            CreateMap<DB_StarchAnalysisHeading, StarchAnalysisHeadingDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_StarchAnalysisHeadingDetail, CreateStarchAnalysisHeadingDetailDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeadingDetail, UpdateStarchAnalysisHeadingDetailDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeadingDetail, StarchAnalysisHeadingDetailDto>().ReverseMap();

            #endregion

            #region Retention Analysis

            CreateMap<DB_RetentionAnalysisHead, CreateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetentionAnalysisHead, UpdateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetentionAnalysisHead, RetentionAnalysisHeadDto>().ReverseMap();

            CreateMap<DB_RetentionAnalysisHead, RetentionAnalysisHeadDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_RetantionAnalysisDetail, CreateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetantionAnalysisDetail, UpdateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetantionAnalysisDetail, RetentionAnalysisDetailDto>().ReverseMap();

            #endregion

            #region Circulation Tank

            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, CreateCirculationTankAirPressureMeasurementTurbidityDto>().ReverseMap();
            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, UpdateCirculationTankAirPressureMeasurementTurbidityDto>().ReverseMap();
            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, CirculationTankAirPressureMeasurementTurbidityDto>().ReverseMap();

            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, CirculationTankAirPressureMeasurementTurbidityDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Water Treatment Analysis

            CreateMap<DB_WaterTreatmentAnalysisResults, CreateWaterTreatmentAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_WaterTreatmentAnalysisResults, UpdateWaterTreatmentAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_WaterTreatmentAnalysisResults, WaterTreatmentAnalysisResultsDto>().ReverseMap();

            CreateMap<DB_WaterTreatmentAnalysisResults, WaterTreatmentAnalysisResultsDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            CreateMap<DB_RetantionAnalysisDetail, CreateRetentionAnalysisHeadDto>();
        }
    }
}