using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_WastePaperCost : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        // Basic info
        [Display(Name = "Sequence No")]
        public int? SequenceNumber { get; set; }



        [Display(Name = "Waybill No")]
        [StringLength(50)]
        public string WaybillNumber { get; set; }

        [Display(Name = "Company")]
        [StringLength(200)]
        public string Company { get; set; }

        [Display(Name = "Vehicle License Plate")]
        [StringLength(20)]
        public string VehicleLicensePlate { get; set; }

        [Display(Name = "Number of Bales")]
        public int? NumberOfBales { get; set; }

        [Display(Name = "Paper Type Received")]
        [StringLength(100)]
        public string ReceivedPaperType { get; set; }

        // Composition
        [Display(Name = "Corrugated (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? CorrugatedPercent { get; set; }

        [Display(Name = "Mixed (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? MixedPercent { get; set; }

        // Quantities
        [Display(Name = "Waybill Quantity (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? WaybillQuantityKg { get; set; }

        [Display(Name = "Gross Vehicle Weight (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GrossVehicleWeightKg { get; set; }

        [Display(Name = "Empty Vehicle Weight (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? EmptyVehicleWeightKg { get; set; }

        [Display(Name = "Gross Entry Quantity (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GrossEntryQuantityKg { get; set; }

        // Bale info
        [Display(Name = "Average Bale Weight (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? AverageBaleWeightKg { get; set; }

        // Quality deductions
        [Display(Name = "Foreign Material Ratio (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? ForeignMaterialPercent { get; set; }

        [Display(Name = "Device Moisture (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? DeviceMoisturePercent { get; set; }

        [Display(Name = "Oven Moisture (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? OvenMoisturePercent { get; set; }

        [Display(Name = "Average Moisture (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? AverageMoisturePercent { get; set; }

        [Display(Name = "Moisture Exemption (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? MoistureExemptionPercent { get; set; }

        [Display(Name = "Net Moisture Ratio (%)")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? NetMoisturePercent { get; set; }

        [Display(Name = "Moisture Deduction (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MoistureDeductionKg { get; set; }

        [Display(Name = "Foreign Material Deduction (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ForeignMaterialDeductionKg { get; set; }

        [Display(Name = "Net Invoice Base (kg)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetInvoiceBaseKg { get; set; }

        // Pricing fields
        [Display(Name = "Agreed Price")]
        [Column(TypeName = "decimal(18,4)")]
        [DataType(DataType.Currency)]
        public decimal? AgreedPrice { get; set; }                   // Anlaşılan Fiyat (per unit? typically per kg or ton)

        [Display(Name = "Gross Amount")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal? GrossAmount { get; set; }                   // Tutar (based on agreed price)

        [Display(Name = "Net Price")]
        [Column(TypeName = "decimal(18,4)")]
        [DataType(DataType.Currency)]
        public decimal? NetPrice { get; set; }                      // Net Fiyat (after deductions per unit)

        [Display(Name = "Net Amount")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal? NetAmount { get; set; }


    }


}
