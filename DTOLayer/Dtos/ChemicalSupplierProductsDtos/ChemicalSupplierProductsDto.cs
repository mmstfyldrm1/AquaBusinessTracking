namespace DTOLayer.Dtos.ChemicalSupplierProductsDtos
{
    public class ChemicalSupplierProductsDto
    {
        public int RecId { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public string CurrentAccountName { get; set; }

        public string Product { get; set; }

        public string Unit { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }

        public int ShiftId { get; set; }
    }
}
