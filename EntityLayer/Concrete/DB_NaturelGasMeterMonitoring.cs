using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_NaturelGasMeterMonitoring : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }



        public int DailyConsumption { get; set; }
        public float Pressure { get; set; }

        public float Heat { get; set; }
        public float CalorificValue { get; set; }
        public decimal StandartCubicmeter { get; set; }
        public float ConversionFactor { get; set; }

        public decimal kW { get; set; }

        public string Explanation { get; set; }

        public int Control { get; set; }

        public int IsApproved { get; set; }


    }
}
