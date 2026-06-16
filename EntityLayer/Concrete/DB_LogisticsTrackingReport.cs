using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_LogisticsTrackingReport : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public DateTime Date { get; set; }                          // TARİH
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

        [JsonIgnore]
        public DB_Department Department { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int AppUserId { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
