namespace DTOLayer.Dtos.KazanChemicalsDtos.KazanChemicalsHeadDtos
{
    public class KazanChemicalsFormDto
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

        public string ShiftName { get; set; }
        public string CreatedByName { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public KazanChemicalsDetaiFormDto Detail { get; set; }
    }
    public class KazanChemicalsDetaiFormDto
    {
        public int RecId { get; set; }

        public decimal Incoming { get; set; }

        public decimal Consumption { get; set; }

        public decimal Remaining { get; set; }

        public int KazanChemicalsHeadId { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
