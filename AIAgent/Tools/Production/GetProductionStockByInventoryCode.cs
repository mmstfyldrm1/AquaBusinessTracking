using AIAgent.Services.Abstract.Production;
using System.Text.Json;

namespace AIAgent.Tools.Production
{
    public class GetProductionStockByInventoryCode : IAiTool
    {
        private readonly IProductionApiService _productionApiService;

        public GetProductionStockByInventoryCode(IProductionApiService productionApiService)
        {
            _productionApiService = productionApiService;
        }

        public string Name => "get_production_stock_by_inventory_code";

        public string Description =>
            "Kullanıcının verdiği inventory_code değerine göre üretim stok bilgisini getirir. " +
            "SONUÇ BİR LİSTEDİR — aynı inventory_code için birden fazla kayıt dönebilir " +
            "(farklı depo veya seri numarasına göre ayrılmış olabilir). " +
            "Her kayıt alanları: SerialCode, InventoryCode, InventoryName, WidthCM, " +
            "SerialQuantity (o seriye ait miktar), StockQuantity (o kayıttaki stok miktarı), " +
            "WarehouseCode, WarehouseName. " +
            "Kullanıcı toplam stok soruyorsa tüm kayıtlardaki StockQuantity değerlerini topla. " +
            "Depo bazında soruyorsa WarehouseName'e göre ayrıştır. " +
            "Liste boşsa, bu ürün için stok kaydı bulunamadığını belirt.";

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
