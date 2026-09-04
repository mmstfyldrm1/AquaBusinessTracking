using DTOLayer.Dtos.SalesScale;

namespace AIAgent.Services.Abstract.Shipment
{
    public interface IShipmentApiService
    {
        Task<List<SalesScaleDto>> GetLast30daysShipment();

        Task<List<SalesScaleDto>> GetWithBySearch(DateTime StartDate, DateTime EndDate);

    }
}
