namespace EntityLayer.Concrete
{
    public class BaseEntity
    {
        public int RecId { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public int? ShiftId { get; set; }
        public int? AppUserId { get; set; }

        public int? DepartmentId { get; set; }

        public DB_Department? Department { get; set; }
        public DB_Shift? Shift { get; set; }
        public DB_AppUser? AppUser { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }




    }
}
