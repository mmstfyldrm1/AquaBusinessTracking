namespace DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail
{
    public class CreateStarchAnalysisHeadingDetailDto
    {
        public int RecId { get; set; }

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

        public int StarchAnalysisHeadingId { get; set; }
    }
}
