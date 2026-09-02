using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace EntityLayer.Concrete
{
    public class DB_DailyShipmentPlan : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string ShipmentNo { get; set; }
        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string District { get; set; }
        public string? Address { get; set; }



        [JsonIgnore]
        public ICollection<DB_LogisticsTrackingReport> LogisticsTrackingReport { get; set; }


    }
}
