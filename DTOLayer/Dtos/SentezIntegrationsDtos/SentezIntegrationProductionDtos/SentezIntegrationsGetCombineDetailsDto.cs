namespace DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationProductionDtos
{
    public class SentezIntegrationsGetCombineDetailsDto
    {
        public DateTime ReceiptDate { get; set; }

        public string CombinationNo { get; set; } // Kombine Numaraları

        public string AssignedResources { get; set; } // Planlanan Set Enleri 

        public string InventoryName { get; set; }
        public decimal Quantity { get; set; } // Kg
        public double FinishDailyQuantity { get; set; } // Set Tekrar Sayısı 
    }
}
