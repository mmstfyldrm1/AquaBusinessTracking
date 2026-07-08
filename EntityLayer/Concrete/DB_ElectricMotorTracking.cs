using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_ElectricMotorTracking : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string ElectricMotorOrderNo { get; set; }

        public string ElectricMotorBrand { get; set; }

        public float kW { get; set; }

        public string Voltage { get; set; }

        public string? Explanation { get; set; }

    }
}
