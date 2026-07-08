namespace DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos
{
    public class CreateBoilerSteamFeedWaterCondensateDataDto
    {


        public DateTime ReceiptDate { get; set; }
        public decimal Boil { get; set; }
        public decimal FeedWater { get; set; }

        public decimal KM2Kodens { get; set; }
        public decimal Hvac { get; set; }

        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }


        public int ShiftId { get; set; }
    }
}
