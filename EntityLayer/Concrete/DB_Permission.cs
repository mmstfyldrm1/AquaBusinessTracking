using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string Module { get; set; }      // ART
        public string Controller { get; set; }  // Basin
        public string Action { get; set; }      // View

        public string Name => $"{Module}.{Controller}.{Action}";
        public string Description { get; set; }


        [JsonIgnore]
        public ICollection<DB_RolePermission> RolePermissions { get; set; }

        [JsonIgnore]
        public ICollection<DB_FavoriteMenuItem> FavoriteMenuItems { get; set; }
    }
}
