namespace DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos
{
    public class DoughPreparationAnalysisResultsDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }

        public string SampleTakenLocation { get; set; }

        public float KM { get; set; }

        public int SR { get; set; }

        public int DryMatter { get; set; }

        public float pH { get; set; }

        public int Conductivity { get; set; }

        public int CaCO3 { get; set; }

        public float Filling { get; set; }

        public int Blur { get; set; }

        public string Explanation { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
