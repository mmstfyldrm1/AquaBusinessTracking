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
    public class DB_RetantionAnalysisDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string LocationName { get; set; }
        public decimal? ConsistencyPercent { get; set; }   // % KM
        public decimal? AshGr { get; set; }                // Kül/gr
        public decimal? FillerPercent { get; set; }        // % dolgu
        public decimal? SrDegree { get; set; }             // SR°
        public decimal? Ph { get; set; }                   // pH

        public int RetentionAnalysisHeadId { get; set; }

        [JsonIgnore]
        public DB_RetentionAnalysisHead RetentionAnalysisHead { get; set; } 


    }
}
