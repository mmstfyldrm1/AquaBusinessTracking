using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_RawMaterialIntake : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public TimeSpan ScaleHours { get; set; } = DateTime.Now.TimeOfDay;

        public string WaybillNo { get; set; }

        public string CurrentAccountName { get; set; }

        public string TruckPlate { get; set; }

        public string Operator { get; set; }

        public decimal WaybillQuantity { get; set; }

        public decimal FilledQuantity { get; set; }

        public decimal EmptyQuantity { get; set; }

        public decimal NetQuantity { get; set; }

    }
}
