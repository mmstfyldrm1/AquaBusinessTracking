using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_CirculationTankAirPressureMeasurementTurbidity : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public TimeSpan Time { get; set; }
        public decimal MachineSpeed { get; set; }
        public string ProductionType { get; set; }
        public decimal Grammage { get; set; }
        public int TurnCount { get; set; }
        public decimal Fau { get; set; }  // FAU - Fuzzy/Flocculation value
        public decimal Ntu { get; set; }  // NTU - Turbidity/Nephelometric value



    }
}
