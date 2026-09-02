namespace DTOLayer.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public bool IsRead { get; set; }
    }
}
