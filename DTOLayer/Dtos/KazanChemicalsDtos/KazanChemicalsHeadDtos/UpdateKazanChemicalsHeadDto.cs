namespace DTOLayer.Dtos.KazanDtos.KazanHeadDtos
{
    public class UpdateKazanChemicalsHeadDto
    {
        public int RecId { get; set; }

        public string InventoryCode { get; set; }
        public string InventoryName { get; set; }

        public string? Day { get; set; }

        public DateTime Date { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
