namespace DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos
{
    public class WaterTreatmentAnalysisResultsDto
    {
        public int RecId { get; set; }
        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }

        public string SampleTakenLocation { get; set; }

        public int DryMatter { get; set; }
        public float Filling { get; set; }
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
