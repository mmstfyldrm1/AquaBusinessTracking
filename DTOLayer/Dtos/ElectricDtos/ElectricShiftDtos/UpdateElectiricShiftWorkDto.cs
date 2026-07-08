namespace DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos
{
    public class UpdateElectiricShiftWorkDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int ShiftId { get; set; }
        public int AppUserId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
