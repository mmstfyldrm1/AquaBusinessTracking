using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_KazanDailyShiftMonitoring : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string ShiftUserName { get; set; }

        public int JobDone { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public int Permission { get; set; }


    }
}
