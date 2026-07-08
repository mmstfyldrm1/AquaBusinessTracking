using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_MassWasteBalance : BaseEntity
    {

        [Key]
        public int RecId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string WasteCode { get; set; }
        public decimal PreviousMonthCarryover { get; set; }
        public decimal UsedInProduction { get; set; }
        public decimal NextMonthCarryover { get; set; }


    }
}
