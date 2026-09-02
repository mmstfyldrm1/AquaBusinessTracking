namespace DTOLayer.Dtos.LogisticsTrackingReportDtos
{
    public class CreateLogisticsTrackingReportDto
    {
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public int ShipmentPlanId { get; set; }
        public string DepartureLocation { get; set; }

        public string ArrivalCountry { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalDistrict { get; set; }

        public string ArrivalAddress { get; set; }
        public string ProcessingCompany { get; set; }
        public string CarrierCompany { get; set; }
        public string TruckPlate { get; set; }
        public string TrailerPlate { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverIdentityNumber { get; set; }
        public string TrailerType { get; set; }
        public string Status { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal ScaleQuantity { get; set; }
        public decimal CoilQuantity { get; set; }
        public DateTime LoadingEntryTime { get; set; }
        public DateTime LoadingDepartureTime { get; set; }
        public TimeSpan OperationDuration { get; set; }
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
