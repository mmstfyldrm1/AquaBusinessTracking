using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_MassWasteSupplier : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CompanyName { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string WasteCode { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }

        public int DepartmentId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
