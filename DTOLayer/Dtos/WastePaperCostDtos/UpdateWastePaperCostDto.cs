namespace DTOLayer.Dtos.WastePaperCost
{
    public class UpdateWastePaperCostDto
    {
        public int RecId { get; set; }


        public int? SequenceNumber { get; set; }


        public DateTime Date { get; set; }


        public string WaybillNumber { get; set; }


        public string Company { get; set; }


        public string VehicleLicensePlate { get; set; }


        public int? NumberOfBales { get; set; }


        public string ReceivedPaperType { get; set; }


        public decimal? CorrugatedPercent { get; set; }


        public decimal? MixedPercent { get; set; }


        public decimal? WaybillQuantityKg { get; set; }


        public decimal? GrossVehicleWeightKg { get; set; }


        public decimal? EmptyVehicleWeightKg { get; set; }


        public decimal? GrossEntryQuantityKg { get; set; }


        public decimal? AverageBaleWeightKg { get; set; }


        public decimal? ForeignMaterialPercent { get; set; }


        public decimal? DeviceMoisturePercent { get; set; }


        public decimal? OvenMoisturePercent { get; set; }


        public decimal? AverageMoisturePercent { get; set; }


        public decimal? MoistureExemptionPercent { get; set; }


        public decimal? NetMoisturePercent { get; set; }


        public decimal? MoistureDeductionKg { get; set; }


        public decimal? ForeignMaterialDeductionKg { get; set; }


        public decimal? NetInvoiceBaseKg { get; set; }



        public decimal? AgreedPrice { get; set; }                   // Anlaşılan Fiyat (per unit? typically per kg or ton)



        public decimal? GrossAmount { get; set; }                   // Tutar (based on agreed price)

        public decimal? NetPrice { get; set; }                      // Net Fiyat (after deductions per unit)


        public decimal? NetAmount { get; set; }

        public int DepartmentId { get; set; }



        public int AppUserId { get; set; }



        public int ShiftId { get; set; }



        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
