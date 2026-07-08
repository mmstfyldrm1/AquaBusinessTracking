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
        public string? BreakLocation { get; set; }
        public string? DowntimeReason { get; set; }
        public string? Explanation { get; set; }
    }
}
