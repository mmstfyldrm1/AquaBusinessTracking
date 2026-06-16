namespace DTOLayer.Dtos.RolePermission
{
    public class RolePermissionDto
    {
        public int RoleId { get; set; }

        public List<PermissionItemDto> Permissions { get; set; }
    }
}
