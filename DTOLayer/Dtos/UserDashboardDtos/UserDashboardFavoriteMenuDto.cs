namespace DTOLayer.Dtos.UserDashboardDtos
{
    public class UserDashboardFavoriteMenuDto
    {
        public int RecId { get; set; }

        public string Controller { get; set; }

        public int ModuleId { get; set; }

        public string Url { get; set; }

        public int DisplayOrder { get; set; }
    }
}
