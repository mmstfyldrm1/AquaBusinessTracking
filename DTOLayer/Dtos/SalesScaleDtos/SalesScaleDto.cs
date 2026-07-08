namespace DTOLayer.Dtos.SalesScale
{
    public class SalesScaleDto
    {

        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public DateTime ScaleDate { get; set; } = DateTime.Now;

        public DateTime ScaleHours { get; set; } = DateTime.Now;

        public decimal ScaleNo { get; set; }

        public string DeliveryNumber { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }

        public string CurrentAccountName { get; set; }

        public string TruckPlate { get; set; }

        public int AppUserId { get; set; } //FK


        public decimal DeliveryQuantity { get; set; }

        public decimal ScaleQuantity { get; set; }

        public int? ScaleGap { get; set; } // Fark

        public string GapSuperVisior { get; set; }

        public string GapDesicion { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }

        public int ShiftId { get; set; }
    }
}
