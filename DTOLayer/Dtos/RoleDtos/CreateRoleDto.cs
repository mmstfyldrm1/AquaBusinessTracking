namespace DTOLayer.Dtos.RoleDtos
{
    public class CreateRoleDto
    {
        public string Name { get; set; }

        public string RoleName { get; set; }

        public List<int> PermissionIds { get; set; } = new();


    }
}
