using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_Basin : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [JsonIgnore]
        public ICollection<DB_BasinMeasurement> Measurements { get; set; }


    }
}
