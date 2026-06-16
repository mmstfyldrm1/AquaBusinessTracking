using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_AppRole : IdentityRole<int>
    {

        public string RoleName { get; set; }
        public string? Explanation { get; set; }

        [JsonIgnore]
        public ICollection<DB_RolePermission> RolePermissions { get; set; }

    }
}
