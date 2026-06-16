namespace EntityLayer.Concrete
{
    public class BaseEntity
    {
        public int RecId { get; set; }

        public int? ShiftId { get; set; }
        public int? AppUserId { get; set; }

        public DB_Shift? Shift { get; set; }
        public DB_AppUser? AppUser { get; set; }


    }
}
