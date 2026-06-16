namespace DTOLayer.Dtos.RolePermission
{
    public class CreateRoleResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RoleName { get; set; }

        public bool Success { get; set; }

        public List<int> PermissionIds { get; set; } = new();

    }
}
