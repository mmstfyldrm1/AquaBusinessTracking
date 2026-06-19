using DTOLayer.Dtos.BasinDtos.BasinMeasurement;

namespace DTOLayer.Dtos.BasinDtos.BasinDto
{
    public class BasinWithMeasurementsDto
    {
        public BasinDto Basin { get; set; }
        public List<BasinMeasurementDto> Measurements { get; set; }
    }
}
