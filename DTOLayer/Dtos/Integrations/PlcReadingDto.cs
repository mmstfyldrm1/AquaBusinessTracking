namespace DTOLayer.Dtos.Integrations
{
    public class PlcReadingDto
    {
        public int RecId { get; set; }
        public string DisplayName { get; set; } = "";
        public string Group { get; set; } = "";
        public string Unit { get; set; } = "";
        public double Value { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}
