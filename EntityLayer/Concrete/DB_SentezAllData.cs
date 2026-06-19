using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_SentezAllData : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        // Basic Production Information
        public DateTime Date { get; set; } = DateTime.Now;              // Tarih
        public string BufferNo { get; set; }                    // Tampon No
        public string ProductType { get; set; }                 // Ürün Cinsi
        public decimal? Grammage { get; set; }                  // Gramaj

        [Display(Name = "Buffer Roll Description")]
        public string BufferRollDescription { get; set; }       // Tampon Fiş Açıklama

        public TimeSpan? StartTime { get; set; }                // Başlangıç Saati
        public TimeSpan? EndTime { get; set; }                  // Bitiş Saati

        [Display(Name = "Ideal Machine Speed (m/min)")]
        public decimal? IdealMachineSpeed { get; set; }         // İdeal Makine Hızı (m/d)

        [Display(Name = "Actual Machine Speed (m/min)")]
        public decimal? ActualMachineSpeed { get; set; }        // Makine Hızı (m/d)

        [Display(Name = "Speed Reduction Reason")]
        public string SpeedReductionReason { get; set; }        // Makine Hız Düşme Nedeni

        [Display(Name = "Buffer Width")]
        public decimal? BufferWidth { get; set; }               // Tampon Genişliği

        // Production Quantities
        [Display(Name = "Produced Quantity (kg)")]
        public decimal? ProducedQuantityKg { get; set; }        // Üretilen Miktar (Kg.)

        [Display(Name = "Defective Quantity (kg)")]
        public decimal? DefectiveQuantityKg { get; set; }       // Kusurlu Miktar (Kg.)

        [Display(Name = "Net Production (kg)")]
        public decimal? NetProductionKg { get; set; }           // Üretilen Net miktar (kg.)

        // Retention / Chemical Additives
        [Display(Name = "Retention Dosage (L/min)")]
        public decimal? RetentionDosageLtMin { get; set; }      // Retansiyon Dozaj (LT/DK)

        [Display(Name = "Retention Dosage (%)")]
        public decimal? RetentionDosagePercent { get; set; }    // Retansiyon Dozaj %

        // Starch Information
        [Display(Name = "Sizer Starch (g/m²)")]
        public decimal? SizerStarchGsm { get; set; }            // Sizer Nişasta (gr/m2)

        [Display(Name = "Operating Starch Solid Content (%)")]
        public decimal? OperatingStarchSolidContent { get; set; } // Çalışma Nişasta %KM

        [Display(Name = "Operating Starch Temperature (°C)")]
        public decimal? OperatingStarchTemperature { get; set; }   // Çalışma Nişasta Sıcaklık

        [Display(Name = "Preparation Starch Solid Content (%)")]
        public decimal? PreparationStarchSolidContent { get; set; } // Hazırlama Nişasta %KM

        [Display(Name = "Preparation Starch Temperature (°C)")]
        public decimal? PreparationStarchTemperature { get; set; }   // Hazırlama Nişasta Sıcaklık

        // Quality Control
        [Display(Name = "QC Number")]
        public string QualityControlNumber { get; set; }        // Kalite Kontrol No

        // Physical Properties - Measured
        [Display(Name = "Measured Grammage Avg (g/m²)")]
        public decimal? MeasuredGrammageAvg { get; set; }       // Ölçülen Gramaj Ort. (g/m2)

        [Display(Name = "Measured Thickness Avg (µm)")]
        public decimal? MeasuredThicknessAvg { get; set; }      // Ölçülen Kalınlık Ort. (µm)

        [Display(Name = "Measured Moisture Avg (%)")]
        public decimal? MeasuredMoistureAvg { get; set; }       // Ölçülen Rutubet Ort. (%)

        // Strength Properties
        [Display(Name = "Burst Strength (kPa)")]
        public decimal? BurstStrengthKpa { get; set; }          // Patlama (kPa)

        [Display(Name = "Burst Index (kPa/g)")]
        public decimal? BurstIndex { get; set; }                // Patlama Index (kPa/Gr)

        [Display(Name = "SCT CD (kN/m)")]
        public decimal? SctCd { get; set; }                     // SCT CD (kN/m)

        [Display(Name = "SCT Index (kN·m/kg)")]
        public decimal? SctIndex { get; set; }                  // SCT Index (kN.m/kg)

        [Display(Name = "RCT (kgf)")]
        public decimal? RctKgf { get; set; }                    // RCT (kgf)

        [Display(Name = "ECT (kN/m)")]
        public decimal? EctKnM { get; set; }                    // ECT (kN/m)

        [Display(Name = "CCT (kN/m)")]
        public decimal? CctKnM { get; set; }                    // CCT (kN/m)

        [Display(Name = "CMT (kN/m)")]
        public decimal? CmtKnM { get; set; }                    // CMT (kN/m)

        // Porosity & Absorption
        [Display(Name = "Gurley Porosity (sn)")]
        public decimal? GurleyPorositySec { get; set; }         // Gurley (sn)

        [Display(Name = "Bendsen Porosity (μm/(Pa·s))")]
        public decimal? BendsenPorosity { get; set; }           // Bendsen (μm/(Pa·s))

        [Display(Name = "Cobb 60 Absorption (g/m²)")]
        public decimal? Cobb60Absorption { get; set; }          // Cobb 60 (g/m2)

        // Tensile & Optical Properties
        [Display(Name = "Tensile Speed (mm/min)")]
        public decimal? TensileSpeed { get; set; }              // Kopma (mm/dak)
        public decimal? Schopper { get; set; }                  // Schopper
        public decimal? Filler { get; set; }                    // Dolgu
        public decimal? Ash { get; set; }                       // Kül

        // Color Properties (CIE Lab)
        [Display(Name = "Color L Value")]
        public decimal? ColorL { get; set; }                    // Renk L
        [Display(Name = "Color A Value")]
        public decimal? ColorA { get; set; }                    // Renk A
        [Display(Name = "Color B Value")]
        public decimal? ColorB { get; set; }                    // Renk B

        // Personnel & Lab Info
        public string Laborant { get; set; }                    // Laborant

        // Silica Additives
        [Display(Name = "Silica Added")]
        public bool? SilicaAdded { get; set; }                  // Silika Varmı

        [Display(Name = "Silica Dosage Amount")]
        public decimal? SilicaDosageAmount { get; set; }        // Silika Dozaj Miktarı

        // ATC Additives
        [Display(Name = "ATC Added")]
        public bool? AtcAdded { get; set; }                     // ATC Varmı

        [Display(Name = "ATC Amount")]
        public decimal? AtcAmount { get; set; }                 // ATC Miktar

        // Dye Additives
        [Display(Name = "Dye Dosage Amount")]
        public decimal? DyeDosageAmount { get; set; }           // Boya Dozaj Miktar

        // Customer & Complaint Info
        [Display(Name = "Suitable for Special Customer")]
        public bool? SuitableForSpecialCustomer { get; set; }   // Özel Müşteriye Uygunmu

        [Display(Name = "Complaint Received")]
        public bool? ComplaintReceived { get; set; }            // Şikayet Alındımı

        // QCS (Quality Control System) Data
        [Display(Name = "QCS Grammage")]
        public decimal? QcsGrammage { get; set; }               // QCS Gramaj

        [Display(Name = "QCS Moisture")]
        public decimal? QcsMoisture { get; set; }               // QCS Rutubet

        // Machine Data
        [Display(Name = "Machine SR")]
        public decimal? MachineSr { get; set; }                 // MakineSR

        [Display(Name = "Pulp Chest SR")]
        public decimal? PulpChestSr { get; set; }               // HamurKasasıSR

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }

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
