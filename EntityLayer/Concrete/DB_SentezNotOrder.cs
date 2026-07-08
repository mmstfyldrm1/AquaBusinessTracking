using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


    }
}
