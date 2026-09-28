using AIAgent.Services.Abstract.Production;
using System.Text.Json;

namespace AIAgent.Tools.Production
{
    public class GetProductionStockByInventoryCodeTool : IAiTool
    {
        private readonly IProductionApiService _productionApiService;

        public GetProductionStockByInventoryCodeTool(IProductionApiService productionApiService)
        {
            _productionApiService = productionApiService;
        }

        public string Name => "get_production_stock_by_inventory_code_tool";

        public string Description =>
            "Retrieves production stock information based on the inventory_code provided by the user. " +
            "THE RESULT IS A LIST — multiple records may be returned for the same inventory_code " +
            "(records may be separated by different warehouses or serial numbers). " +
            "Each record contains the following fields: SerialCode, InventoryCode, InventoryName, WidthCM, " +
            "SerialQuantity (quantity belonging to that serial), StockQuantity (stock quantity in that record), " +
            "WarehouseCode, WarehouseName. " +
            "If the user asks for total stock, sum the StockQuantity values across all records. " +
            "If the user asks for stock by warehouse, group and separate the results by WarehouseName. " +
            "If the list is empty, state that no stock records were found for this product. " +
            "Always respond to the user in Turkish.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new
            {
                InventoryCode = new { type = "string", description = "Sorgulanacak stok/envanter kodu" }
            },
            required = new[] { "InventoryCode" }
        };
        public async Task<object> ExecuteAsync(string? argumentsJson = null)
        {
            var rawArgs = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(argumentsJson);
            if (rawArgs is null)
                return new { error = "Argümanlar okunamadı." };

            var args = new Dictionary<string, JsonElement>(rawArgs, StringComparer.OrdinalIgnoreCase);

            if (!args.TryGetValue("inventoryCode", out var inventoryCodeElement))
            {
                return new { error = "inventoryCode parametresi zorunludur.", gelen = argumentsJson };
            }

            var inventoryCode = inventoryCodeElement.GetString();
            if (string.IsNullOrWhiteSpace(inventoryCode))
            {
                return new { error = "inventoryCode boş geldi." };
            }

            try
            {
                return await _productionApiService.GetStockByInventoryCode(inventoryCode);
            }
            catch (Exception ex)
            {
                return new { error = $"Stok verisi alınamadı: {ex.Message}" };
            }
        }
    }
}
