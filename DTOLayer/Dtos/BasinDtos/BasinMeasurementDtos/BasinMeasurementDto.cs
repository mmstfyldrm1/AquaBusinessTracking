namespace DTOLayer.Dtos.BasinDtos.BasinMeasurement
{
    public class BasinMeasurementDto
    {

        public int RecId { get; set; }
        public int BasinId { get; set; }
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

        public int DepartmentId { get; set; }

        public string BasinName { get; set; }
        public int AppUserId { get; set; }

        public string? CreatedByName { get; set; }
        public int ShiftId { get; set; }
        public string? ShiftName { get; set; }


        public DateTime InsertDate { get; set; } = DateTime.Now;

        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }
    }
}
