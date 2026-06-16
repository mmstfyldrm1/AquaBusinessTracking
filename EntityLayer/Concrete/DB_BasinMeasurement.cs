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
    public class DB_BasinMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BasinId { get; set; }
        public DB_Basin Basin { get; set; }
        public decimal? EnteranceAKM { get; set; }
        public decimal? OutAKM { get; set; }
        public decimal? EnteranceKOI { get; set; }
        public decimal? OutKOI { get; set; }
        public decimal? TN { get; set; }
        public decimal? Fosfat { get; set; }
        public decimal? pH { get; set; }
        public decimal? Renk { get; set; }

        public decimal? DO { get; set; }
        public decimal? Imhoff { get; set; }

        public string StartHours { get; set; }
        public string EndHours   { get; set; }
    }
}
