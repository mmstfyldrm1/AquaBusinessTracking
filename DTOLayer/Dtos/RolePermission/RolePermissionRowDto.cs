using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.RolePermission
{
    public class RolePermissionRowDto
    {
        public string RoleName { get; set; }

        public string Name { get; set; }
        public int? PermissionId { get; set; }
    }
}
