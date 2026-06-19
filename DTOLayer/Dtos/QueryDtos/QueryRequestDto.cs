namespace DTOLayer.Dtos.QueryDtos
{
    public class QueryRequestDto
    {
        public string Query { get; set; }
        public List<QueryParameterDto>? Parameters { get; set; }
    }
}
