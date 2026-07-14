using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_Message
    {
        [Key]
        public int RecId { get; set; }

        public int SenderId { get; set; }
        public DB_AppUser Sender { get; set; } = null!;

        public int ReceiverId { get; set; }
        public DB_AppUser Receiver { get; set; } = null!;

        public string Content { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
    }
}
