using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_LabWork : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string LabTestName { get; set; }

        public string LabTestRequest { get; set; }
        public string LabTestCount { get; set; }
        public string LabTestUserNames { get; set; }





    }
}
