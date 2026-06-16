
namespace DTOLayer.Dtos.RoleDtos
{
    public class UpdateRoleDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? RoleName { get; set; }

        public List<int>? PermissionIds { get; set; } = new();
        public List<string>? PermissionNames { get; set; } = new();




    }
}
