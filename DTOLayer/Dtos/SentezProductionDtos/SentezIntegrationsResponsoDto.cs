namespace DTOLayer.Dtos.SentezProductionDtos
{
    public class SentezIntegrationsResponsoDto<T>
    {


        public bool IsOk { get; set; }


        public int ErrorCode { get; set; }


        public string? ErrorMessage { get; set; }


        public List<string>? ServerMessages { get; set; }


        public List<T>? Data { get; set; }
    }
}
