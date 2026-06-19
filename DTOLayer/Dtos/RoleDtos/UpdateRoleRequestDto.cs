namespace DTOLayer.Dtos.RoleDtos
{
    public class UpdateRoleRequestDto
    {
        public string? Name { get; set; }
        public string RoleName { get; set; }

        public string? Explanation { get; set; }

        public string? NormalizedName { get; set; }
    }
}
