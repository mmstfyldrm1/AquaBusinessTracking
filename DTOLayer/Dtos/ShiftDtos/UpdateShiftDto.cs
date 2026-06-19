namespace DTOLayer.Dtos.ShiftDtos
{
    public class UpdateShiftDto
    {
        public int RecId { get; set; }
        public string ShiftName { get; set; }
        public string ShiftCode { get; set; }
        public TimeSpan? ShiftStartHours { get; set; }
        public TimeSpan? ShiftEndHours { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
