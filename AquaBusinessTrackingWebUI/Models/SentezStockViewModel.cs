using DTOLayer.Dtos.SentezProductionDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class SentezStockViewModel
    {
        public SentezIntegrationsResponsoDto<SentezProductionDto> PreviousDay { get; set; }
        public SentezIntegrationsResponsoDto<SentezProductionDto> Stock { get; set; }
    }
}
