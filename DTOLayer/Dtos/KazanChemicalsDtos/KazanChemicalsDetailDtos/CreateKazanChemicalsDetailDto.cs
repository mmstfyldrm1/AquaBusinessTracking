namespace DTOLayer.Dtos.KazanDtos.KazanDetailDtos
{
    public class CreateKazanChemicalsDetailDto
    {
        public decimal Incoming { get; set; }

        public decimal Consumption { get; set; }

        public decimal Remaining { get; set; }

        public int KazanChemicalsHeadId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
