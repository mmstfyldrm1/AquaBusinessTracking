namespace DTOLayer.Dtos.LogisticsTrackingReportDtos
{
    public class LogisticsTrackingReportDto
    {
        public int RecId { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;                     // TARİH
        public string CarrierCompany { get; set; }                  // NAKLİYE FİRMASI
        public string DepartureLocation { get; set; }               // ÇIKIŞ YERİ
        public string ArrivalLocation { get; set; }                 // VARIŞ YERİ
        public string Vehicle { get; set; }                         // ARAÇ
        public string DriverNameOrPlate { get; set; }               // SOFÖR İSMİ/ PLAKA
        public decimal? Price { get; set; }                         // FİYAT
        public string ProcessingCompany { get; set; }               // FİRMA (İŞLEM YAPILAN)
        public string Description { get; set; }                     // AÇIKLAMA        
        public string Status { get; set; }                          // DURUMU
        public string InvoiceNumber { get; set; }
        public int DepartmentId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
