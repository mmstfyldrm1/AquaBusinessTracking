using DTOLayer.Dtos.ResponseComboBoxDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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
