using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_BoilerSteamFeedWaterCondensateData : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }


        public decimal Boil { get; set; }
        public decimal FeedWater { get; set; }

        public decimal KM2Kodens { get; set; }
        public decimal Hvac { get; set; }



    }
}
