using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_PlcReading
    {
        [Key]
        public int RecId { get; set; }
        public DateTime ReadingTime { get; set; } = DateTime.UtcNow;
        public double Value { get; set; }  // tüm değerler double olarak

        public int PlcTagId { get; set; }
        public DB_PlcTags PlcTag { get; set; } = null!;
    }
}
