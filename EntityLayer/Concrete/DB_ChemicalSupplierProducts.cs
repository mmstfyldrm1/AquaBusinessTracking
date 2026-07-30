using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_ChemicalSupplierProducts : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public string CurrentAccountName { get; set; }

        public string Product { get; set; }

        public string Unit { get; set; }



    }
}
