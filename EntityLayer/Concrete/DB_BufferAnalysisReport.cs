using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_BufferAnalysisReport : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public TimeSpan? BufferExitTime { get; set; }               // TAMPON ÇIKIŞ SAATİ


        public TimeSpan? SampleCollectionTime { get; set; }         // NUMUNE ALMA SAATİ


        public TimeSpan? SampleResultTime { get; set; }             // NUMUNE SONUÇ VERME SAATİ


        public string BufferNo { get; set; }                        // TAMPON NO


        public string ProductType { get; set; }                     // ÜRÜN CİNSİ


        public decimal? TargetGrammage { get; set; }                // ÜRÜN GRAMAJI


        public decimal? GrammageTop { get; set; }                   // GRAMAJ (gr/m²) ( S )


        public decimal? GrammageMiddle { get; set; }                // GRAMAJ (gr/m²) ( O )


        public decimal? GrammageBottom { get; set; }                // GRAMAJ (gr/m²) ( T )


        public decimal? LabAverageGrammage { get; set; }            // LAB. OR. GRAMAJ (gr/m²)


        public decimal? QcsGrammage { get; set; }                   // QCS GRAMAJ


        public decimal? ThicknessMicrons { get; set; }              // KALINLIK (µm)


        public decimal? MoistureTop { get; set; }                   // RUTUBET % ( S )


        public decimal? MoistureMiddle { get; set; }                // RUTUBET % ( O )


        public decimal? MoistureBottom { get; set; }                // RUTUBET % ( T )


        public decimal? AverageMoisture { get; set; }               // ORT RUTUBET %


        public decimal? QcsMoisture { get; set; }                   // QCS RUTUBET %


        public decimal? BurstStrengthKpa { get; set; }              // PATLAMA (kpa)


        public decimal? BurstIndex { get; set; }                    // PATLAMA (İndex)


        public decimal? Cobb60Uncoated { get; set; }                // COBB 60 (gr/m2) Ü.K


        public decimal? Cobb60Coated { get; set; }                  // COBB 60 (gr/m2) A.K


        public decimal? RctKnM { get; set; }                        // RCT (KN/m)


        public decimal? CmtNewton { get; set; }                     // CMT (N)


        public decimal? CctKnM { get; set; }                        // CCT (KN/m)


        public decimal? SctCd { get; set; }                         // SCT (KN/m) (CD)


        public decimal? SctIndexCd { get; set; }                    // SCT (İndex) (CD)


        public decimal? GurleyPorosity { get; set; }                // GURLEY (ml/sn)


        public decimal? BentsenPorosityUncoated { get; set; }       // BENTSEN (ml/dak) Ü.K


        public decimal? ColorLStar { get; set; }                    // RENK ( L*)


        public decimal? ColorAStar { get; set; }                    // RENK ( a*)


        public decimal? ColorBStar { get; set; }                    // RENK ( b*)


        public decimal? TensileStrengthWidth { get; set; }          // KOP. MUK. (m) (EN)


        public decimal? TensileStrengthLength { get; set; }         // KOP. MUK. (m) (BOY)


        public decimal? FillerPercent { get; set; }                 // DOLGU (%)


        public decimal? DyeDosageAmount { get; set; }               // BOYA DOZAJ MİKYARI


        public decimal? SizerGrammage { get; set; }                 // SIZER GRAMAJ


        public decimal? Starch { get; set; }                        // NİŞASTA


        public decimal? Silica { get; set; }                        // SLİKA



        public bool? SuitableForMondi { get; set; }                 // MONDİ'YE UYGUN


        public bool? AquaEcoFL16 { get; set; }                      // AQUA ECO FL (16)


        public bool? AquaFL18 { get; set; }                         // AQUA FL (18)


        public bool? AquaPowerFL20 { get; set; }                    // AQUA POWER FL (20)


        public bool? AquaHighPowerFL22 { get; set; }                // AQUA HIGH POWER FL (22)


        public bool? AquaTestliner { get; set; }                    // AQUA TESTLINER


        public bool? TlProductionGivenToFl { get; set; }            // TL ÜRETİM FL'YE VERİLDİ


        public string Description { get; set; }                     // AÇIKLAMA


    }
}
