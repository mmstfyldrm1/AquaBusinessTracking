using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.BasinDtos.BasinMeasurement
{
    public class CreateBasinMeasurementDto
    {
        
        public int BasinId { get; set; }
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
        public string EndHours { get; set; }
    }
}
