using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos
{
    public class CreateElectricShiftWorkDto
    {
        public int ShiftId { get; set; } 
        public int AppUserId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
