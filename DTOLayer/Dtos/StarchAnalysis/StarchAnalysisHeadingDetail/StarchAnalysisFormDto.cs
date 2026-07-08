namespace DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail
{

    public class StarchAnalysisFormDto
    {
        public int RecId { get; set; }

        public DateTime ReceiptDate { get; set; }
        public int SampleCollectionTime { get; set; }
        public int SampleResultDeliveryTime { get; set; }
        public string? Explanation { get; set; }
        public string? Location { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }
        public int ShiftId { get; set; }
        public short? InUse { get; set; }
        public int? DeletedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public StarchAnalysisDetailFormDto StarchAnalysisDetailForm { get; set; }
    }

    public class StarchAnalysisDetailFormDto
    {
        public int RecId { get; set; }

        public DateTime ReceiptDate { get; set; }
        public TimeSpan? Time { get; set; }
        public decimal? MachineSpeed { get; set; }
        public string ProductionType { get; set; }
        public decimal? Grammage { get; set; }
        public int? TurnCount { get; set; }
        public decimal? Fau { get; set; }
        public decimal? Ntu { get; set; }
        public decimal? DryMatterOven { get; set; }
        public decimal? DryMatterRefractometer { get; set; }
        public decimal? Temperature1 { get; set; }
        public decimal? ViscosityCp1 { get; set; }
        public int? ViscosityFord1 { get; set; }

    }
}
