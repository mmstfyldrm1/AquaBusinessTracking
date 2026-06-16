using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DB_DoughPreparationAnalysisResults
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }

        public string SampleTakenLocation { get; set; }

        public float KM { get; set; }

        public int SR { get; set; }

        public int DryMatter { get; set; }

        public float pH { get; set; }

        public int Conductivity { get; set; }

        public int CaCO3 { get; set; }

        public float Filling { get; set; }

        public int Blur { get; set; }

        public string Explanation { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public DB_Department Department { get; set; }


        public int AppUserId { get; set; }
        
        [JsonIgnore]
        public DB_AppUser AppUser { get; set; }

        public int ShiftId { get; set; }

        [JsonIgnore]
        public DB_Shift Shift { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }


    }
}
