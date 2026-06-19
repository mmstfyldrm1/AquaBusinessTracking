using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_RolePermission
    {


        public int RoleId { get; set; } // IdentityRole Id
        public int PermissionId { get; set; }

        [JsonIgnore]
        public DB_Permission Permission { get; set; }

        [JsonIgnore]
        public DB_AppRole Role { get; set; }
    }
}
