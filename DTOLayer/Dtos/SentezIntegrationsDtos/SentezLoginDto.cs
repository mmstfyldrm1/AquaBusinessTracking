namespace DTOLayer.Dtos.SentezProductionDtos
{
    public class SentezLoginDto
    {


        public bool IsOk { get; set; }

        public int? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public List<string>? ServerMessages { get; set; }

        public string? Data { get; set; }






    }
}
