using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_KazanDailyShiftMonitoring : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public int ShihtId { get; set; }

        [JsonIgnore]
        public DB_Shift Shiht { get; set; }

        public string ShiftUserName { get; set; }

        public int JobDone { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public int Permission { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }

        public int AppUserId { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
