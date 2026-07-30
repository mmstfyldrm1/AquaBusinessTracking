namespace DTOLayer.Dtos.SentezProductionDtos
{
    public class SentezUpdateResponseDto
    {
        public bool IsOk { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string>? ServerMessages { get; set; }

        public object Data { get; set; } // veya bool, API ne döndürüyorsa
    }
}
