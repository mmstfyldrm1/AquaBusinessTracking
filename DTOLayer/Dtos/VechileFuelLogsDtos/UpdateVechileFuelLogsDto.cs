namespace DTOLayer.Dtos.VechileFuelLogsDtos
{
    public class UpdateVechileFuelLogsDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string VehicleLicensePlate { get; set; }             // ARAÇ PLAKASI
        public string VehicleName { get; set; }                     // ARAÇ ADI
        public string EngineHourOrKm { get; set; }                  // MOTOR SAATİ/KM
        public decimal? FuelDeliveredLiters { get; set; }           // VERİLEN MAZOT MİK/LT
        public string Recipient { get; set; }                       // TESLİM ALAN
        public string ResponsibleDepartment { get; set; }           // İLGİLİ BİRİM

        public decimal? FuelPricePerLiter { get; set; }             // Mazot lt fiyat
        public decimal? TotalAmount { get; set; }

        public int DepartmentId { get; set; }


        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int AppUserId { get; set; }



        public int ShiftId { get; set; }



        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
