using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_LogisticsTrackingReport : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

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

    }
}
