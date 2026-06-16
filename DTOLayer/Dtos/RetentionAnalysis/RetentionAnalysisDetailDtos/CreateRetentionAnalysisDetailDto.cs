namespace DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisDetailDtos
{
    public class CreateRetentionAnalysisDetailDto
    {
        public int RecId { get; set; }

        public string LocationName { get; set; }
        public decimal? ConsistencyPercent { get; set; }   // % KM
        public decimal? AshGr { get; set; }                // Kül/gr
        public decimal? FillerPercent { get; set; }        // % dolgu
        public decimal? SrDegree { get; set; }             // SR°
        public decimal? Ph { get; set; }                   // pH

        public int RetentionAnalysisHeadId { get; set; }

    }
}
