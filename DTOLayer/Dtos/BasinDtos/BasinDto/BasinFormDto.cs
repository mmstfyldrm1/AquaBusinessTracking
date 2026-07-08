
namespace DTOLayer.Dtos.BasinDtos.BasinDto
{
    public class BasinFormDto
    {
        public int RecId { get; set; }

        public DateTime ReceiptDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }
        public int ShiftId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public BasinMeasurementFormDto Measurement { get; set; } = new();



        public class BasinMeasurementFormDto
        {
            public int Id { get; set; }
            public decimal? EnteranceAKM { get; set; }
            public decimal? OutAKM { get; set; }
            public decimal? EnteranceKOI { get; set; }
            public decimal? OutKOI { get; set; }
            public decimal? TN { get; set; }
            public decimal? Fosfat { get; set; }
            public decimal? pH { get; set; }
            public decimal? Renk { get; set; }
            public decimal? DO { get; set; }
            public decimal? Imhoff { get; set; }
            public string StartHours { get; set; }
            public string EndHours { get; set; }
        }
    }
}
