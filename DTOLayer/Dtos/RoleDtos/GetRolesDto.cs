using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.RoleDtos
{
    public class GetRolesDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public string RoleCode { get; set; }

        public string Name { get; set; }

        public List<string>? SelectedRoles { get; set; }
    }
}
