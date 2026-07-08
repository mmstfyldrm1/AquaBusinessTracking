using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_PlanningScorBoardView : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string PlanNo { get; set; }
        public string? UploadPdf { get; set; }
    }
}
