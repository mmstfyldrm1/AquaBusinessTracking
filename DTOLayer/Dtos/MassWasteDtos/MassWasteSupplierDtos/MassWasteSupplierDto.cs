namespace DTOLayer.Dtos.MassWasteDtos.MassWasteSupplierDtos
{
    public class MassWasteSupplierDto
    {
        public int RecId { get; set; }
        public int Month { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;
        public string CompanyName { get; set; }
        public string ShiftName { get; set; }
        public string CreatedByName { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string WasteCode { get; set; }

        public int DepartmentId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }
        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
