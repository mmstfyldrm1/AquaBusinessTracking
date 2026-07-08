namespace DTOLayer.Dtos.SentezAllDataDtos
{
    public class UpdateSentezAllDataDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;              // Tarih
        public string BufferNo { get; set; }                    // Tampon No
        public string ProductType { get; set; }                 // Ürün Cinsi
        public decimal? Grammage { get; set; }                  // Gramaj

        public string BufferRollDescription { get; set; }       // Tampon Fiş Açıklama

        public TimeSpan? StartTime { get; set; }                // Başlangıç Saati
        public TimeSpan? EndTime { get; set; }                  // Bitiş Saati

        public decimal? IdealMachineSpeed { get; set; }         // İdeal Makine Hızı (m/d)

        public decimal? ActualMachineSpeed { get; set; }        // Makine Hızı (m/d)

        public string SpeedReductionReason { get; set; }        // Makine Hız Düşme Nedeni

        public decimal? BufferWidth { get; set; }               // Tampon Genişliği

        // Production Quantities
        public decimal? ProducedQuantityKg { get; set; }        // Üretilen Miktar (Kg.)

        public decimal? DefectiveQuantityKg { get; set; }       // Kusurlu Miktar (Kg.)

        public decimal? NetProductionKg { get; set; }           // Üretilen Net miktar (kg.)

        // Retention / Chemical Additives
        public decimal? RetentionDosageLtMin { get; set; }      // Retansiyon Dozaj (LT/DK)

        public decimal? RetentionDosagePercent { get; set; }    // Retansiyon Dozaj %

        // Starch Information
        public decimal? SizerStarchGsm { get; set; }            // Sizer Nişasta (gr/m2)

        public decimal? OperatingStarchSolidContent { get; set; } // Çalışma Nişasta %KM

        public decimal? OperatingStarchTemperature { get; set; }   // Çalışma Nişasta Sıcaklık

        public decimal? PreparationStarchSolidContent { get; set; } // Hazırlama Nişasta %KM

        public decimal? PreparationStarchTemperature { get; set; }   // Hazırlama Nişasta Sıcaklık

        // Quality Control
        public string QualityControlNumber { get; set; }        // Kalite Kontrol No

        // Physical Properties - Measured
        public decimal? MeasuredGrammageAvg { get; set; }       // Ölçülen Gramaj Ort. (g/m2)

        public decimal? MeasuredThicknessAvg { get; set; }      // Ölçülen Kalınlık Ort. (µm)

        public decimal? MeasuredMoistureAvg { get; set; }       // Ölçülen Rutubet Ort. (%)

        // Strength Properties
        public decimal? BurstStrengthKpa { get; set; }          // Patlama (kPa)

        public decimal? BurstIndex { get; set; }                // Patlama Index (kPa/Gr)

        public decimal? SctCd { get; set; }                     // SCT CD (kN/m)

        public decimal? SctIndex { get; set; }                  // SCT Index (kN.m/kg)

        public decimal? RctKgf { get; set; }                    // RCT (kgf)

        public decimal? EctKnM { get; set; }                    // ECT (kN/m)

        public decimal? CctKnM { get; set; }                    // CCT (kN/m)

        public decimal? CmtKnM { get; set; }                    // CMT (kN/m)

        public decimal? GurleyPorositySec { get; set; }         // Gurley (sn)

        public decimal? BendsenPorosity { get; set; }           // Bendsen (μm/(Pa·s))

        public decimal? Cobb60Absorption { get; set; }          // Cobb 60 (g/m2)

        // Tensile & Optical Properties
        public decimal? TensileSpeed { get; set; }              // Kopma (mm/dak)
        public decimal? Schopper { get; set; }                  // Schopper
        public decimal? Filler { get; set; }                    // Dolgu
        public decimal? Ash { get; set; }                       // Kül

        // Color Properties (CIE Lab)
        public decimal? ColorL { get; set; }                    // Renk L
        public decimal? ColorA { get; set; }                    // Renk A
        public decimal? ColorB { get; set; }                    // Renk B

        // Personnel & Lab Info
        public string Laborant { get; set; }                    // Laborant

        // Silica Additives
        public bool? SilicaAdded { get; set; }                  // Silika Varmı

        public decimal? SilicaDosageAmount { get; set; }        // Silika Dozaj Miktarı

        // ATC Additives
        public bool? AtcAdded { get; set; }                     // ATC Varmı

        public decimal? AtcAmount { get; set; }                 // ATC Miktar

        // Dye Additives
        public decimal? DyeDosageAmount { get; set; }           // Boya Dozaj Miktar

        // Customer & Complaint Info
        public bool? SuitableForSpecialCustomer { get; set; }   // Özel Müşteriye Uygunmu

        public bool? ComplaintReceived { get; set; }            // Şikayet Alındımı

        public decimal? QcsGrammage { get; set; }               // QCS Gramaj

        public decimal? QcsMoisture { get; set; }               // QCS Rutubet

        // Machine Data
        public decimal? MachineSr { get; set; }                 // MakineSR


        public decimal? PulpChestSr { get; set; }               // HamurKasasıSR

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
