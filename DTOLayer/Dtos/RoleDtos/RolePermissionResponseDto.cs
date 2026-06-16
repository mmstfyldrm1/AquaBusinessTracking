namespace DTOLayer.Dtos.RoleDtos
{
    public class RolePermissionResponseDto
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Name { get; set; }

        public List<int>? PermissionIds { get; set; } = new();
        public List<RolePermissionItemDto> Permissions { get; set; }

        public List<string>? PermissionNames { get; set; } = new();
    }

    public class RolePermissionItemDto
    {
        public int PermissionId { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
