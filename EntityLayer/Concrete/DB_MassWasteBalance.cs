using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_MassWasteBalance : BaseEntity
    {

        [Key]
        public int RecId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string WasteCode { get; set; }
        public decimal PreviousMonthCarryover { get; set; }
        public decimal UsedInProduction { get; set; }
        public decimal NextMonthCarryover { get; set; }
        [JsonIgnore]
        public DB_Department Department { get; set; }

        public int DepartmentId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public int AppUserId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
