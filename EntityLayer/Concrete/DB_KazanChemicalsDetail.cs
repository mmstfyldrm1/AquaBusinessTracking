using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DB_KazanChemicalsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public decimal Incoming { get; set; }

        public decimal Consumption { get; set; }

        public decimal Remaining { get; set; }

        public int KazanChemicalsHeadId { get; set; }

        [JsonIgnore]
        public DB_KazanChemicalsHead KazanChemicalsHead { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
