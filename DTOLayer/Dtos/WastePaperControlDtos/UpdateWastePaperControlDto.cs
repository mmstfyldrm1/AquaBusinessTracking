namespace DTOLayer.Dtos.WastePaperControlDtos
{
    public class UpdateWastePaperControlDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int? SequenceNumber { get; set; }                     // Sıra No





        public string WaybillNumber { get; set; }                    // İrsaliye No


        public string Company { get; set; }                          // Firma


        public string VehicleLicensePlate { get; set; }              // Araç Plakası


        public int? NumberOfBales { get; set; }                      // Balya Sayısı


        public string ReceivedPaperType { get; set; }                // Gelen Kağıt Türü

        public decimal? CorrugatedPercent { get; set; }              // Oluklu (%)


        public decimal? MixedPercent { get; set; }                   // Karışık (%)

        public decimal? WaybillQuantityKg { get; set; }              // İrsaliye Miktarı (kg)

        public decimal? GrossVehicleWeightKg { get; set; }           // Dolu Araç Ağırlığı (kg)


        public decimal? EmptyVehicleWeightKg { get; set; }           // Boş Araç Ağırlığı (kg)


        public decimal? GrossEntryQuantityKg { get; set; }           // Brüt Giriş Miktarı (kg)


        public decimal? AverageBaleWeightKg { get; set; }            // Ortalama Balya Ağırlığı (kg)


        public decimal? ForeignMaterialPercent { get; set; }         // Yabancı Madde Oranı (%)

        public decimal? DeviceMoisturePercent { get; set; }          // Cihaz ile Nem (%)


        public decimal? OvenMoisturePercent { get; set; }            // Etüvde Nem (%)


        public decimal? AverageMoisturePercent { get; set; }         // Nem Ortalama (%)

        public decimal? MoistureExemptionPercent { get; set; }       // Nem Muafiyeti (%)

        public decimal? NetMoisturePercent { get; set; }             // Net Nem Oranı (%)

        public decimal? MoistureDeductionKg { get; set; }            // Nem Kesintisi (kg)


        public decimal? ForeignMaterialDeductionKg { get; set; }     // Yabancı Madde Kesinti (kg)
        public decimal? NetInvoiceBaseKg { get; set; }               // Net (Faturaya Esas) Kg

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
