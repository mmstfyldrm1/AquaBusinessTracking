using static EntityLayer.Enums.NotificationTargetTypes;

namespace DTOLayer.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {

        public NotificationTargetType TargetType { get; set; }
        public List<int>? UserIds { get; set; }      // SingleUser/MultipleUsers için
        public string? RoleName { get; set; }         // Role için
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Url { get; set; }
        public string Icon { get; set; } = "bell-outline";
        public string Color { get; set; } = "info";    // info, warning, success, danger
    }
}
