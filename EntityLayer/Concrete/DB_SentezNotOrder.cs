using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_SentezNotOrder : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string Description { get; set; }                     // AÇIKLAMA

        public DateTime? InvoiceDate { get; set; }                  // irs.Tarih

        public string InvoiceNumber { get; set; }                   // İrs Numarası-Fatura no

        public string SupplierCompany { get; set; }                 // Gelen Firma

        public string SynthesisCode { get; set; }                   // SENTEZ KODU

        public string ProductMaterial { get; set; }                 // Ürün/Malzeme

        public decimal? Quantity { get; set; }                      // Miktar

        public string Unit { get; set; }                            // Birim


        public string ProductMaterialGroup { get; set; }            // Ürün/Malzeme Grubu

        public DateTime? WarehouseEntryDate { get; set; }           // Depoya giriş tarihi

        public int? WaitingPeriod { get; set; }                     // BEKLEME SÜRESİ
        public string PurchaseDescription { get; set; }

        public int? DepartmentId { get; set; }

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
