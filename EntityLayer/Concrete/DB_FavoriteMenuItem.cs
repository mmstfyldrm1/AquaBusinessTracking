using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_FavoriteMenuItem : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public int ModuleId { get; set; }

        [JsonIgnore]
        public DB_Permission Permission { get; set; }

        public string Url { get; set; }

        public int DisplayOrder { get; set; }


    }
}
