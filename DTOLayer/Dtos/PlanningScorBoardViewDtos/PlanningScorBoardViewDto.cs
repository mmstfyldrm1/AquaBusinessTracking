using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace DTOLayer.Dtos.PlanningScorBoardViewDtos
{
    public class PlanningScorBoardViewDto
    {
        public int RecId { get; set; }

        public string PlanNo { get; set; }
        public string UploadPdf { get; set; }

        [JsonIgnore]
        public IFormFile? UploadPdfs { get; set; }
        public int DepartmentId { get; set; }

        public DateTime? ReceiptDate { get; set; } = DateTime.Now;

        public int AppUserId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string CreatedByName { get; set; }

        public string ShiftName { get; set; }
        public DateTime? DeleteDate { get; set; }

        public int ShiftId { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }


    }
}
