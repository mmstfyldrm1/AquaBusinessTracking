using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_BufferGramajProfile : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public decimal BufferNo { get; set; }

        public int SampleNo { get; set; }

        public int Gramaj { get; set; }
        public int Thickness { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }

        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }




    }
}
