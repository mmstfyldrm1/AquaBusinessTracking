using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.RoleDtos
{
    public class CreateRoleRequestDto
    {
        public string? Name { get; set; }
        public string RoleName { get; set; }
        public string? Explanation { get; set; }
    }
}
