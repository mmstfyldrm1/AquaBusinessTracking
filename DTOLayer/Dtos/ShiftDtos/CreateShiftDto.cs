using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.ShiftDtos
{
    public class CreateShiftDto
    {

        public string ShiftName { get; set; }
        public string ShiftCode { get; set; }

        public TimeSpan? ShiftStartHours { get; set; }

        public TimeSpan? ShiftEndHours { get; set; }
        public DateTime? InsertDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
