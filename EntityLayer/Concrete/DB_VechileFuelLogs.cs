using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_VechileFuelLogs : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string VehicleLicensePlate { get; set; }             // ARAÇ PLAKASI
        public string VehicleName { get; set; }                     // ARAÇ ADI
        public string EngineHourOrKm { get; set; }                  // MOTOR SAATİ/KM
        public decimal? FuelDeliveredLiters { get; set; }           // VERİLEN MAZOT MİK/LT
        public string Recipient { get; set; }                       // TESLİM ALAN
        public string ResponsibleDepartment { get; set; }           // İLGİLİ BİRİM

        public decimal? FuelPricePerLiter { get; set; }             // Mazot lt fiyat
        public decimal? TotalAmount { get; set; }


    }
}
