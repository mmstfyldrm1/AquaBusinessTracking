using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.BasinDtos.BasinDto
{
    public class CreateBasinDto
    {
        public int? RecId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }
        public int ShiftId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
