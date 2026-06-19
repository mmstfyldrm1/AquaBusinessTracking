namespace AquaBusinessTrackingWebUI.Services
{
    public class LoadShiftListService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoadShiftListService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


    }
}
