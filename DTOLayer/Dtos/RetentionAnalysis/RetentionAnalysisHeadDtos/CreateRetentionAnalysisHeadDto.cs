namespace DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos
{
    public class CreateRetentionAnalysisHeadDto
    {


        public DateTime Date { get; set; }

        public TimeSpan? SampleCollectionTime { get; set; }

        public TimeSpan? SampleResultTime { get; set; }

        public decimal? MachineSpeedRpm { get; set; }

        public decimal? BasisWeightGrM2 { get; set; }

        public string? ProductionType { get; set; }

        public decimal? RetentionPercent { get; set; }

        public decimal? RetentionFeedLtMin { get; set; }

        public decimal? PulpFlowLtMin { get; set; }

        public decimal? UnderScreenCaCO3 { get; set; }

        public decimal? SilicaLtHour { get; set; }

        public decimal? AtcFeedLtHour { get; set; }

        public decimal? PlydacmacFeedLtHour { get; set; }

        public decimal? PacFeedLtHour { get; set; }

        public decimal? DiscFilterPulpFlowLtMin { get; set; }

        public string? Location { get; set; }

        public string Explanation { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }
        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
