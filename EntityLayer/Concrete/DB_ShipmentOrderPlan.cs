using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_ShipmentOrderPlan : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public int CurrentAccountId { get; set; }

        public string CurrentAccountCode { get; set; }

        public string CurrentAccountName { get; set; }

        public DateTime PlanDate { get; set; }

        public int Status { get; set; }

        public List<DB_ShipmentOrderPlanDetail> ShipmentOrderPlanDetail { get; set; }
            = new List<DB_ShipmentOrderPlanDetail>();
    }
}
