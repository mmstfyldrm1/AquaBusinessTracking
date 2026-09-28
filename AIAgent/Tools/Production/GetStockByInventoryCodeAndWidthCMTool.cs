using AIAgent.Services.Abstract.Production;
using System.Text.Json;

namespace AIAgent.Tools.Production
{
    public class GetStockByInventoryCodeAndWidthCMTool : IAiTool
    {
        private readonly IProductionApiService _productionApiService;

        public GetStockByInventoryCodeAndWidthCMTool(IProductionApiService productionApiService)
        {
            _productionApiService = productionApiService;
        }

        public string Name => "get_stock_by_inventory_code_and_width_cm_tool";

        public string Description => "Gets stock information for a specific inventory code and width in centimeters. Requires two parameters: InventoryCode and WidthCm. Use the returned data to answer the user's question. Always respond to the user in Turkish.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new
            {
                InventoryCode = new { type = "string", description = "Sorgulanacak stok/envanter kodu" },
                WidthCM = new { type = "number", description = "Sorgulanacak Ebat" }
            },
            required = new[] { "InventoryCode", "WidthCM" }
        };

        public async Task<object> ExecuteAsync(string? argumentsJson = null)
        {
            var rawArgs = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(argumentsJson);

            if (rawArgs is null)
                return new { error = "Argümanlar okunamadı." };

            var args = new Dictionary<string, JsonElement>(
                rawArgs,
                StringComparer.OrdinalIgnoreCase);


            if (!args.TryGetValue("inventoryCode", out var inventoryCodeElement))
            {
                return new
                {
                    error = "inventoryCode parametresi zorunludur.",
                    gelen = argumentsJson
                };
            }

            var inventoryCode = inventoryCodeElement.GetString();

            if (string.IsNullOrWhiteSpace(inventoryCode))
            {
                return new { error = "inventoryCode boş geldi." };
            }


            if (!args.TryGetValue("widthCm", out var widthCmElement))
            {
                return new
                {
                    error = "widthCm parametresi zorunludur.",
                    gelen = argumentsJson
                };
            }

            if (!widthCmElement.TryGetDecimal(out var widthCm))
            {
                return new
                {
                    error = "widthCm sayısal bir değer olmalıdır.",
                    gelen = argumentsJson
                };
            }

            try
            {
                double widthCmDouble = Convert.ToDouble(widthCm);
                return await _productionApiService.GetStockByInventoryCodeAndWidthCM(inventoryCode, widthCmDouble);

            }
            catch (Exception ex)
            {
                return new
                {
                    error = $"Stok verisi alınamadı: {ex.Message}"
                };
            }
        }
    }
}
