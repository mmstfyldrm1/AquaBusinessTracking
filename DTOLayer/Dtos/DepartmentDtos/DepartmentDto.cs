namespace DTOLayer.Dtos.DepartmentDtos
{
    public class DepartmentDto
    {
        public int RecId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string? Explanation { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
