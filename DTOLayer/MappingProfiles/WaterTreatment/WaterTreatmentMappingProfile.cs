using AutoMapper;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using DTOLayer.Dtos.MassWasteDtos.MassWasteBalanceDtos;
using DTOLayer.Dtos.MassWasteDtos.MassWasteSupplierDtos;
using DTOLayer.Dtos.PurificationChemicalsConsumptionDtos;
using DTOLayer.Dtos.TestDtos.TestDetailDtos;
using DTOLayer.Dtos.TestDtos.TestHeadDtos;
using EntityLayer.Concrete;

namespace DTOLayer.MappingProfiles.WaterTreatment
{
    public class WaterTreatmentMappingProfile : Profile
    {
        public WaterTreatmentMappingProfile()
        {
            #region Basin

            CreateMap<DB_Basin, CreateBasinDto>().ReverseMap();
            CreateMap<DB_Basin, UpdateBasinDto>().ReverseMap();
            CreateMap<DB_Basin, BasinDto>().ReverseMap();
            CreateMap<DB_Basin, BasinDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Basin Measurement


            CreateMap<DB_BasinMeasurement, CreateBasinMeasurementDto>().ReverseMap();
            CreateMap<DB_BasinMeasurement, UpdateBasinMeasurementDto>().ReverseMap();
            CreateMap<DB_BasinMeasurement, BasinMeasurementDto>().ReverseMap();

            #endregion

            #region Test

            CreateMap<DB_TestHeader, CreateTestHeadDto>().ReverseMap();
            CreateMap<DB_TestHeader, UpdateTestHeadDto>().ReverseMap();
            CreateMap<DB_TestHeader, TestHeadDto>().ReverseMap();

            CreateMap<DB_TestHeader, TestHeadDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_TestDetail, CreateTestDetailDto>().ReverseMap();
            CreateMap<DB_TestDetail, UpdateTestDetailDto>().ReverseMap();
            CreateMap<DB_TestDetail, TestDetailDto>().ReverseMap();

            #endregion

            #region Mass Waste Balance

            CreateMap<DB_MassWasteBalance, CreateMassWasteBalanceDto>().ReverseMap();
            CreateMap<DB_MassWasteBalance, UpdateMassWasteBalanceDto>().ReverseMap();
            CreateMap<DB_MassWasteBalance, MassWasteBalanceDto>().ReverseMap();

            CreateMap<DB_MassWasteBalance, MassWasteBalanceDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Mass Waste Supplier

            CreateMap<DB_MassWasteSupplier, CreateMassWasteSupplierDto>().ReverseMap();
            CreateMap<DB_MassWasteSupplier, UpdateMassWasteSupplierDto>().ReverseMap();
            CreateMap<DB_MassWasteSupplier, MassWasteSupplierDto>().ReverseMap();

            CreateMap<DB_MassWasteSupplier, MassWasteSupplierDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion

            #region Purification Chemicals Consumption

            CreateMap<DB_PurificationChemicalsConsumption, CreatePurificationChemicalsConsumptionDto>().ReverseMap();
            CreateMap<DB_PurificationChemicalsConsumption, UpdatePurificationChemicalsConsumptionDto>().ReverseMap();
            CreateMap<DB_PurificationChemicalsConsumption, PurificationChemicalsConsumptionDto>().ReverseMap();

            CreateMap<DB_PurificationChemicalsConsumption, PurificationChemicalsConsumptionDto>()
                .ForMember(x => x.ShiftName,
                    x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName,
                    x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            #endregion
        }
    }
}