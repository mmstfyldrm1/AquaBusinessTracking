using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EntityLayer.Enums.Enums;

namespace EntityLayer.Concrete
{
    public class DB_LogisticsTrackingReport : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
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
        public ShipmentStatus Status { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal ScaleQuantity { get; set; }
        public decimal CoilQuantity { get; set; }
        public DateTime LoadingEntryTime { get; set; }
        public DateTime LoadingDepartureTime { get; set; }
        public TimeSpan OperationDuration { get; set; }
        public int ShipmentPlanId { get; set; }
        public DB_DailyShipmentPlan DailyShipmentPlan { get; set; }
    }
}
