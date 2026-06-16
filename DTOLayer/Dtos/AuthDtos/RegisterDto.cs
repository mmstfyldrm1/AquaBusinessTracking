using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.AuthDtos
{
    public class RegisterDto
    {

        public string Name { get; set; }

        public string? SurName { get; set; }

        public string? CoverImgUrl { get; set; }

        public string? UserName { get; set; }

        public int DepartmentId { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string Password { get; set; }
    }
}
