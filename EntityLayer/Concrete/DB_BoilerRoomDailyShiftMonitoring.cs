using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_BoilerRoomDailyShiftMonitoring : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string PersonelToWork { get; set; }

        public bool WorkIsDone { get; set; }

        public string Explanation { get; set; }

        public bool WorkPermit { get; set; }

        public string NextShiftWork { get; set; }




    }
}
