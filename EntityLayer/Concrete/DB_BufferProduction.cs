using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_BufferProduction : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string Product { get; set; }

        public int ShiftSupervisorUserId { get; set; }

        public decimal GrPerM2 { get; set; }

        public int BufferNo { get; set; }

        public DateTime? BufferStart { get; set; }

        public DateTime? BufferEnd { get; set; }

        public int TotalDurationMinutes { get; set; }

        public int DowntimeMinutes { get; set; }

        public decimal BufferSpeed { get; set; }

        public decimal BufferWidthCm { get; set; }

        public int BufferSetCount { get; set; }

        public decimal TheoreticalBufferKg { get; set; }

        public decimal MeasuredKg { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public DB_AppUser? ShiftSupervisorUser { get; set; }
    }
}
