using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_WinderCoilTracking : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public int AppUserId { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public string BufferNo { get; set; }

        public string PaperType { get; set; }

        public int SetNo { get; set; }

        public int Gramaj { get; set; }

        public DateTime SetCutterStartDate { get; set; }

        public DateTime SetCutterEndDate { get; set; }

        public int MachineSpeed { get; set; }

        public float CoilDiameter { get; set; }

        public int CoilLength { get; set; }

        public int OutDiamater { get; set; }

        public int AdditionalNumber { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }

        public int ShiftId { get; set; } //FK

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public int? Coil1 { get; set; }
        public int? Coil2 { get; set; }
        public int? Coil3 { get; set; }
        public int? Coil4 { get; set; }
        public int? Coil5 { get; set; }
        public int? Coil6 { get; set; }
        public int? Coil7 { get; set; }
        public int? Coil8 { get; set; }


        public string? Explanation { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}
