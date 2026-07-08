using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_WarehouseRequestWait : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string WaybillNo { get; set; }
        public string WaybillInvoiceNo { get; set; }
        public string IncomingCurrentAccountName { get; set; }
        public string SentezInventoryCode { get; set; }
        public string SentezInventoryName { get; set; }
        public decimal Quanity { get; set; }
        public string Unit { get; set; }
        public string Explanation { get; set; }
        public string SentezInventoryGroup { get; set; }

        public TimeSpan WarehouseEntryDate { get; set; }
        public TimeSpan ReturnDate { get; set; }
        public string WaitingTime { get; set; }


    }
}
