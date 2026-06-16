namespace DTOLayer.Dtos.RolePermission
{
    public class PermissionDto
    {
        public int RecId { get; set; }
        public string Module { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
    }
}