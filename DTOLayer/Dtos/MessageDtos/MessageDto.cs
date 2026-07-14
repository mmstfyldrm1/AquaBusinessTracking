namespace DTOLayer.Dtos.MessageDtos
{
    public class MessageDto
    {

        public int RecId { get; set; }

        public int SenderId { get; set; }


        public int ReceiverId { get; set; }


        public string Content { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
    }
}
