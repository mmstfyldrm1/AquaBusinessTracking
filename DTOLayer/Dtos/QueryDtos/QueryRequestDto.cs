using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.QueryDtos
{
    public class QueryRequestDto
    {
        public string Query { get; set; }
        public List<QueryParameterDto>? Parameters { get; set; }
    }
}
