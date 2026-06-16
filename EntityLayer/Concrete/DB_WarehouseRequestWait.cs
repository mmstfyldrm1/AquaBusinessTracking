using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public DB_Department Department { get; set; }
        public TimeSpan WarehouseEntryDate { get; set; }
        public TimeSpan ReturnDate { get; set; }
        public string WaitingTime { get; set; }
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
