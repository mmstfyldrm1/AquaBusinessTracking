using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_SalesScale : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public DateTime ScaleDate { get; set; } = DateTime.Now;

        public DateTime ScaleHours { get; set; } = DateTime.Now;

        public decimal ScaleNo { get; set; }

        public string DeliveryNumber { get; set; }

        public string CurrentAccountName { get; set; }

        public string TruckPlate { get; set; }

        public int AppUserId { get; set; } //FK

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; } // Navigation property

        public decimal DeliveryQuantity { get; set; }

        public decimal ScaleQuantity { get; set; }

        public int? ScaleGap { get; set; } // Fark

        public string GapSuperVisior { get; set; }

        public string GapDesicion { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }

        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}
