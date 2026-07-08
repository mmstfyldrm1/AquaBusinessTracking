using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace DTOLayer.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }

        public string DepartmentName { get; set; }
        public string UserName { get; set; }

        public int DepartmentId { get; set; }

        public string PhoneNumber { get; set; }

        public string CoverImgUrl { get; set; }

        [JsonIgnore]
        public IFormFile? ProfileImage { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Email { get; set; }

        public List<string>? RoleName { get; set; } = new();




    }
}
