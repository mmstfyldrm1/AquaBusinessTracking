namespace DTOLayer.Dtos.SentezIntegrationsDtos
{
    public class SentezIntegrationsGetStockByInventoryCode
    {
        public string SerialCode { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public decimal? WidthCM { get; set; }

        public decimal? SerialQuantity { get; set; }

        public decimal? StockQuantity { get; set; }
        public string WarehouseCode { get; set; }

        public string WarehouseName { get; set; }

    }
}
