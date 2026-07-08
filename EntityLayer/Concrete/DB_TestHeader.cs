using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_TestHeader : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string TestDepartmentName { get; set; }



        [JsonIgnore]
        public ICollection<DB_TestDetail> TestDetails { get; set; }



    }
}
