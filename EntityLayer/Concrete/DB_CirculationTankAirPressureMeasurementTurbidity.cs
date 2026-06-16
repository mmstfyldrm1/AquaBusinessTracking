using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_CirculationTankAirPressureMeasurementTurbidity : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal MachineSpeed { get; set; }
        public string ProductionType { get; set; }
        public decimal Grammage { get; set; }
        public int TurnCount { get; set; }
        public decimal Fau { get; set; }  // FAU - Fuzzy/Flocculation value
        public decimal Ntu { get; set; }  // NTU - Turbidity/Nephelometric value

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }


        public int AppUserId { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }
    }
}
