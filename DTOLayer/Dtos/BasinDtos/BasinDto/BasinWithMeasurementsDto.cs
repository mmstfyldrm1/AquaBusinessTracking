using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.BasinDtos.BasinDto
{
    public class BasinWithMeasurementsDto
    {
        public BasinDto Basin { get; set; }
        public List<BasinMeasurementDto> Measurements { get; set; }
    }
}
