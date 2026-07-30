using EntityLayer.Concrete;

namespace DataAccsessLayer.Seed
{
    public class PermissionSeed
    {
        public static async Task SeedAsync(AquaBusinessTrackingContext context)
        {

            var modules = new List<(string Module, string Controller, string Description)>
            {
                // ================= ARITMA =================
                ("ARITMA", "Basin", "AAT Lab. Analiz Defteri"),
                ("ARITMA", "PurificationChemicalsConsumption", "Arıtma Kimyasal Tüketim"),
                ("ARITMA", "Test", "Endüstriyel Deneme İzleme"),
                ("ARITMA", "MassWasteSupplier", "Kütle Denklik Firma Bazlı"),
                ("ARITMA", "MassWasteBalance", "Kütle Denklik Atık Kodu Bazlı"),
            
                // ================= M2 KANTAR =================
                ("M2KANTAR", "SalesScale", "Araç Listesi"),
                ("M2KANTAR", "IncomingGoodsTracking", "Gelen Malzeme Takibi"),
            
                // ================= KAZAN =================
                ("KAZAN", "KazanChemicals", "Kazan Kimyasal Takip Sistemi"),
                ("KAZAN", "BoilerSteamFeedWaterCondensateData", "Kazan Kondens Takip Sistemi"),
                ("KAZAN", "NaturelGasMeterMonitoring", "Kazan Doğalgaz Takip Sistemi"),
                ("KAZAN", "BoilerRoomDailyShiftMonitoring", "Kazan Vardiya Takip Sistemi"),
            
                // ================= MEKANIK BAKIM =================
                ("MEKANIKBAKIM", "Maintenance", "Mekanik Bakım"),
            
                // ================= HAMUR HAZIRLAMA =================
                ("HAMURHAZIRLAMA", "DoughPreparation", "Hamur Girişi"),
            
                // ================= KIMYASAL =================
                ("KIMYASAL", "PapperMachineChemical", "Kağıt Makinesi Kimyasalları"),
                ("KIMYASAL", "WaterPreparationAndConsumption", "Su Hazırlama ve Tüketim"),
                ("KIMYASAL", "ChemicalSupplierProducts", "Tedarikçi Kimyasal Ürünleri"),
            
                // ================= MALZEME DEPO =================
                ("MALZEMEDEPO", "WarehouseRequestWait", "Depo Talep Bekleyen"),
                ("MALZEMEDEPO", "LogisticsTrackingReport", "Lojistik Takip Raporu"),
                ("MALZEMEDEPO", "SentezNotOrders", "Sentezde Siparişi Olmayanlar"),
                ("MALZEMEDEPO", "VehicleFuelLogs", "Araç Yakıt Takip Raporu"),
            
                // ================= YAŞ KISIM =================
                ("YASKISIM", "MachineStop", "Yaş Kısım"),
            
                // ================= KURU KISIM =================
                ("KURUKISIM", "BufferProduction", "Kuru Kısım"),
            
                // ================= KALITE =================
                ("KALITE", "DoughPreparationAnalysisResult", "Hamur Analiz Sonucu"),
                ("KALITE", "CirculationTankAirPressureMeasurementTurbidity", "Devir Daim Tankı Sonuçları"),
                ("KALITE", "StarchAnalysis", "Nişasta Analiz Sonuçları"),
                ("KALITE", "LabWork", "Laboratuvar İş Takip Sistemi"),
                ("KALITE", "SentezAllData", "Sentez Veri Takip Sistemi"),
                ("KALITE", "WaterTreatmentAnalysisResults", "Su Arıtma Analiz Sonuçları"),
                ("KALITE", "BufferAnalysisReport", "Tampon Analiz Raporu"),
                ("KALITE", "OilAnalysisReport", "Yağ Analiz Raporu"),

                // ================= Admin Dashboard =================
                ("ADMIN", "AdminLayoutEnergyComponentPartial", "Elektirik Tüketimi Özeti"),
                ("ADMIN", "AdminLayoutIntakeRawMaterialComponentPartial", "Atık Kağıt Giriş"),
                ("ADMIN", "AdminLayoutNaturelGasTrackingComponentPartial", "Doğalgaz Tüketimi Özeti"),
                ("ADMIN", "AdminLayoutRawmaterialsComponentPartial", "Kimyasal Su Arıtma Tüketim"),
                ("ADMIN", "AdminLayoutShippingSalesComponentPartial", "Satış  Takip Sistemi"),
                ("ADMIN", "AdminLayoutStanceComponentPartial", "Duruş Özeti"),
                ("ADMIN", "AdminLayoutStatisticComponentPartial", "Plc Özet Tablosu"),
                ("ADMIN", "AdminLayoutStockComponentPartial", "Üretim Stok Tablosu"),
                ("ADMIN", "AdminLayoutSummaryComponentPartial", "Genel Özet"),
            
                // ================= BOBIN KESME =================
                ("BOBINKESME", "WinderCoilLength", "Bobin Takip"),
                ("BOBINKESME", "WinderCoilTracking", "Kombin Takip"),
            
                // ================= KAĞIT SATIN ALMA =================
                ("KAGITSATINALMA", "WastePaperControl", "Hammadde Kontrol"),
                ("KAGITSATINALMA", "WastePaperCost", "Hammadde Maliyet"),
            
                // ================= PLANLAMA =================
                ("PLANLAMA", "Planning", "Dün Sarf Edilenler"),
                ("PLANLAMA", "PlanningScorBoardView", "Plan Formu Takibi"),
            
                // ================= KAĞIT KANTAR =================
                ("KAGITKANTAR", "RawMaterials", "Hammadde Takip"),
            
                // ================= ELEKTRIK =================
                ("ELEKTRIK", "ElectricMotorTracking", "Motor Takip"),
                ("ELEKTRIK", "ElectricShiftWorking", "Vardiya Takip"),
                ("ELEKTRIK", "CumulativeElectricityConsumption", "Tüketim Takip"),
                ("ELEKTRIK", "ElectricMeterLocation", "Sayaç Takip"),
            
                // ================= OTOMASYON =================
                ("OTOMASYON", "PlcMachine", "Plc Takip"),
                ("OTOMASYON", "PlcMachineTags", "Plc Tag Takip"),
            
                // ================= AYARLAR =================
                ("AYARLAR", "Users", "Kullanıcı Listesi"),
                ("AYARLAR", "Roles", "Rol Listesi"),
                ("AYARLAR", "Shift", "Vardiya Listesi")
            };

            var existing = context.Db_Permission
                .Select(p => new { p.Module, p.Controller, p.Action })
                .ToList();

            var existingSet = existing
                .Select(e => $"{e.Module}|{e.Controller}|{e.Action}")
                .ToHashSet();

            var list = new List<DB_Permission>();

            foreach (var m in modules)
            {
                var actions = new[]
                {
                    ("View", $"{m.Description} - Görüntüleme"),
                    ("Add", $"{m.Description} - Ekleme"),
                    ("Update", $"{m.Description} - Güncelleme"),
                    ("Delete", $"{m.Description} - Silme")
                };

                foreach (var (action, description) in actions)
                {
                    var key = $"{m.Module}|{m.Controller}|{action}";

                    if (existingSet.Contains(key))
                        continue;

                    list.Add(new DB_Permission
                    {
                        Module = m.Module,
                        Controller = m.Controller,
                        Action = action,
                        Description = description
                    });

                }
            }

            if (list.Any())
            {
                await context.Db_Permission.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
        }
    }
}
