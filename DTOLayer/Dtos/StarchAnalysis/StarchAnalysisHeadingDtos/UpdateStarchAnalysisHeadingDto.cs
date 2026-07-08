namespace DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDtos
{
    public class UpdateStarchAnalysisHeadingDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }
        public string Explanation { get; set; }

        public string Location { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public short? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
