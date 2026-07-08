namespace DTOLayer.Dtos.UserDashboardDtos
{
    public class UserDashboardAddFavoriteModuleDto
    {
        public string Controller { get; set; }

        public int ModuleId { get; set; }

        public int? AppUserId { get; set; }

        public string Url { get; set; }

        public int DisplayOrder { get; set; }

        public int? DepartmentId { get; set; }
    }
}
