using EntityLayer.Concrete;

namespace DTOLayer.Dtos.UserDtos
{
    public class GetUserDto : DB_AppUser
    {
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }

    }
}
