using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.PapperMachineChemicalDtos;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutRawmaterialsComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutRawmaterialsComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync(int machineId)
        {
            var start = DateTime.Today;
            var end = start.AddDays(1);

            var cilent = _httpClientFactory.CreateClient();
            var response = await cilent.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/rawmaterials");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                return View(new RawMaterialsDto
                {
                    WaterPreparationAndConsumption = new List<WaterPreparationAndConsumptionDto>(),
                    PapperMachineChemical = new List<PapperMachineChemicalDto>()
                });
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<RawMaterialsDto>(json);

            if (values == null)
                return View(new RawMaterialsDto
                {
                    WaterPreparationAndConsumption = new List<WaterPreparationAndConsumptionDto>(),
                    PapperMachineChemical = new List<PapperMachineChemicalDto>()
                });

            var model = new RawMaterialsDto
            {
                WaterPreparationAndConsumption = values.WaterPreparationAndConsumption
                    .OrderByDescending(x => x.ReceiptDate)
                    .Take(10)
                    .ToList(),

                PapperMachineChemical = values.PapperMachineChemical
                    .OrderByDescending(x => x.ReceiptDate)
                    .Take(10)
                    .ToList()
            };

            return View(model);
        }

    }

}