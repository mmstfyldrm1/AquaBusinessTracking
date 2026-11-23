namespace DTOLayer.Dtos.SalesScaleDtos.EsitIntegrations
{
    public class CreateSalesScaleIntegrationsDto
    {
        public string? token { get; set; }

        /// <summary>Tartıma ait id değeri</summary>
        public long? Seq { get; set; }

        /// <summary>Birinci tartıma ait id değeri (Yalnızca 2. Tartımda bulunur)</summary>
        public long? SeqNum1 { get; set; }

        /// <summary>Tartımın uzak veri transferi durumu</summary>
        public bool? Synch { get; set; }

        /// <summary>Tartım kaydının uzak veritabanındaki id değeri</summary>
        public long? RDBseq { get; set; }

        /// <summary>Uyumsoft e-irsaliye durumu</summary>
        public bool? Status { get; set; }

        /// <summary>Aracın sabit daralı olup olmaması</summary>
        public string? RecType { get; set; }

        /// <summary>Tartımı yapılan aracın id değeri (Araç tanımı yapılmışsa)</summary>
        public string? VehicleID { get; set; }

        /// <summary>Araç plakası</summary>
        public string? Plate { get; set; }

        /// <summary>Tartıma ait fiş numarası</summary>
        public long? TicketNo { get; set; }

        /// <summary>Birinci tartımın yapıldığı tarih</summary>
        public string? WeighTime1 { get; set; }

        /// <summary>İkinci tartımın yapıldığı tarih</summary>
        public string? WeighTime2 { get; set; }

        /// <summary>Birinci tartımda araç ağırlığı (Dara ağırlığı)</summary>
        public int? Weight1 { get; set; }

        /// <summary>İkinci tartımda araç ağırlığı (Dara ağırlığı)</summary>
        public int? Weight2 { get; set; }

        /// <summary>Birinci ve ikinci tartımın ağırlık farkı</summary>
        public int? Net { get; set; }

        public bool? ManualTare { get; set; }

        /// <summary>İndikatörde noktanın yeri</summary>
        public string? IndicatorDotPoint { get; set; }

        /// <summary>Birinci tartımın yapıldığı kantar numarası</summary>
        public string? ScaleNo1 { get; set; }

        /// <summary>İkinci tartımın yapıldığı kantar numarası</summary>
        public string? ScaleNo2 { get; set; }

        /// <summary>Firma kodu</summary>
        public string? FirmCode { get; set; }

        /// <summary>Firma adı</summary>
        public string? FirmName { get; set; }

        /// <summary>Malzeme kodu</summary>
        public string? MaterialCode { get; set; }

        /// <summary>Malzeme tanımı</summary>
        public string? MaterialName { get; set; }

        /// <summary>Malzeme birim fiyatı</summary>
        public float? MaterialUnitPrice { get; set; }

        /// <summary>Malzemenin KDV oranı (%)</summary>
        public float? MaterialPriceVAT { get; set; }

        /// <summary>Sipariş numarası</summary>
        public string? OrderNo { get; set; }

        /// <summary>Sürücü kodu</summary>
        public string? DriverCode { get; set; }

        /// <summary>Sürücü adı</summary>
        public string? DriverName { get; set; }

        /// <summary>Sürücü soy adı</summary>
        public string? DriverSurname { get; set; }


        // --- TABLO 2: Değişkenler - 2 ---

        /// <summary>Sürücü id değeri</summary>
        public string? DriverId { get; set; }

        public string? Code1 { get; set; }
        public string? CName1 { get; set; }
        public string? Code2 { get; set; }
        public string? CName2 { get; set; }
        public string? Code3 { get; set; }
        public string? CName3 { get; set; }
        public string? Code4 { get; set; }
        public string? CName4 { get; set; }
        public string? Code5 { get; set; }
        public string? CName5 { get; set; }
        public string? Code6 { get; set; }
        public string? CName6 { get; set; }
        public string? Code7 { get; set; }
        public string? CName7 { get; set; }
        public string? Code8 { get; set; }
        public string? CName8 { get; set; }
        public string? Code9 { get; set; }
        public string? CName9 { get; set; }
        public string? Code10 { get; set; }
        public string? CName10 { get; set; }

        /// <summary>E-irsaliye numarası</summary>
        public string? WaybillNo { get; set; }

        /// <summary>Geliş net ağırlık</summary>
        public string? NetValPrevious { get; set; }

        /// <summary>Araç tipi</summary>
        public string? VehicleType { get; set; }

        /// <summary>Tartı fiyatı</summary>
        public float? WeighingPrice { get; set; }

        /// <summary>KDV oranı (%)</summary>
        public float? WeighingPriceVAT { get; set; }

        /// <summary>Fire değeri</summary>
        public float? LossVal { get; set; }

        /// <summary>Fire adedi</summary>
        public int? LossUnit { get; set; }

        /// <summary>Fire birimi (% veya kg)</summary>
        public string? LossType { get; set; }

        /// <summary>Dolum miktarı</summary>
        public float? FillingVal { get; set; }

        /// <summary>Gelen araç – Giden araç</summary>
        public string? Direction { get; set; }

        /// <summary>Birinci tartımı gerçekleştiren operator</summary>
        public string? Operator1 { get; set; }

        /// <summary>İkinci tartımı gerçekleştiren operator</summary>
        public string? Operator2 { get; set; }

        public long? ImagesSeq { get; set; }

        /// <summary>İrsaliyenin basılıp basılmama durumu</summary>
        public bool? WaybillPrinted { get; set; }

        public string? CheckCode { get; set; }

        /// <summary>Kaydın manuel olarak silinme durumu</summary>
        public int? ManuelDelete { get; set; }

        /// <summary>Plaka tanıma türü</summary>
        public int? RecogType { get; set; }

        /// <summary>Birinci tartıma ait DBA verisinin id değeri</summary>
        public long? DbaWeigh1Id { get; set; }

        /// <summary>İkinci tartıma ait DBA verisinin id değeri</summary>
        public long? DbaWeigh2Id { get; set; }

        /// <summary>DBA gönderilme durumu (0 gönderildi anlamına gelir)</summary>
        public string? DbaS { get; set; }

        /// <summary>Ölçüm bilgileri sonuç mesajı</summary>
        public string? DbaMsg { get; set; }

        /// <summary>Konteyner dara ağırlığı</summary>
        public string? ContainerTare { get; set; }

        /// <summary>Tartımı yapılan aracın dara geçerlilik süresi</summary>
        public string? TareDate { get; set; }

        // Fotoğraflar (Byte Dizileri)
        public byte[]? Weigh1Image1 { get; set; }
        public byte[]? Weigh1Image2 { get; set; }
        public byte[]? Weigh1Image3 { get; set; }
        public byte[]? Weigh1Image4 { get; set; }

        public byte[]? Weigh2Image1 { get; set; }
        public byte[]? Weigh2Image2 { get; set; }
        public byte[]? Weigh2Image3 { get; set; }
        public byte[]? Weigh2Image4 { get; set; }

        /// <summary>Tartım verisine eklenen tüm dosya ekleri</summary>
        public List<DocumentItem>? Documents { get; set; } = new List<DocumentItem>();
    }
}
