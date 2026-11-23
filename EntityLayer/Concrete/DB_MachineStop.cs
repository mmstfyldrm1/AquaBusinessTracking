using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_MachineStop : BaseEntity
    {
        [Key]
        public int RecId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? DowntimeDuration { get; set; }
        public string? PointofRupture { get; set; }
        public string? ReasonDisconnection { get; set; }
        public string? Equipment { get; set; }
        public string? Explanation { get; set; }
    }
}
