using EntityLayer.Concrete;

namespace DataAccsessLayer.Seed
{
    public class PermissionSeed
    {
        public static async Task SeedAsync(AquaBusinessTrackingContext context)
        {
            if (context.Db_Permission.Any())
                return;

            var modules = new List<(string Module, string Controller, string Description)>
            {
                // ================= ARITMA =================
                ("ARITMA", "AATLabAnalysis", "AAT Lab. Analiz Defteri"),
                ("ARITMA", "PurificationChemicalConsumption", "Arıtma Kimyasal Tüketim"),
                ("ARITMA", "IndustrialTest", "Endüstriyel Deneme İzleme"),
                ("ARITMA", "MassWasteSupplier", "Kütle Denklik Firma Bazlı"),
                ("ARITMA", "MassWasteBalance", "Kütle Denklik Atık Kodu Bazlı"),
            
                // ================= M2 KANTAR =================
                ("M2KANTAR", "SalesScale", "Araç Listesi"),
                ("M2KANTAR", "IncomingGoodsTracking", "Gelen Malzeme Takibi"),
            
                // ================= KAZAN =================
                ("KAZAN", "KazanChemicals", "Kazan Kimyasal Takip Sistemi"),
                ("KAZAN", "CondensateTracking", "Kazan Kondens Takip Sistemi"),
                ("KAZAN", "NaturalGasTracking", "Kazan Doğalgaz Takip Sistemi"),
                ("KAZAN", "BoilerRoomDailyShiftMonitoring", "Kazan Vardiya Takip Sistemi"),
            
                // ================= MEKANIK BAKIM =================
                ("MEKANIKBAKIM", "Maintenance", "Mekanik Bakım"),
            
                // ================= HAMUR HAZIRLAMA =================
                ("HAMURHAZIRLAMA", "DoughPreparation", "Hamur Girişi"),
            
                // ================= KIMYASAL =================
                ("KIMYASAL", "PaperMachineChemical", "Kağıt Makinesi Kimyasalları"),
                ("KIMYASAL", "WaterPreparationConsumption", "Su Hazırlama ve Tüketim"),
            
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
                ("KALITE", "DoughPreparationAnalysis", "Hamur Analiz Sonucu"),
                ("KALITE", "CirculationTankAnalysis", "Devir Daim Tankı Sonuçları"),
                ("KALITE", "StarchAnalysis", "Nişasta Analiz Sonuçları"),
                ("KALITE", "LabWork", "Laboratuvar İş Takip Sistemi"),
                ("KALITE", "SentezAllData", "Sentez Veri Takip Sistemi"),
                ("KALITE", "WaterTreatmentAnalysis", "Su Arıtma Analiz Sonuçları"),
                ("KALITE", "BufferAnalysisReport", "Tampon Analiz Raporu"),
                ("KALITE", "OilAnalysisReport", "Yağ Analiz Raporu"),
            
                // ================= BOBIN KESME =================
                ("BOBINKESME", "WinderCoilLength", "Bobin Takip"),
                ("BOBINKESME", "WinderCoilTracking", "Kombin Takip"),
            
                // ================= KAĞIT SATIN ALMA =================
                ("KAGITSATINALMA", "WastePaperControl", "Hammadde Kontrol"),
                ("KAGITSATINALMA", "WastePaperCost", "Hammadde Maliyet"),
            
                // ================= PLANLAMA =================
                ("PLANLAMA", "ProductionPlan", "Üretim Planı"),
            
                // ================= KAĞIT KANTAR =================
                ("KAGITKANTAR", "RawMaterials", "Hammadde Takip"),
            
                // ================= ELEKTRIK =================
                ("ELEKTRIK", "ElectricMotorTracking", "Motor Takip"),
                ("ELEKTRIK", "ElectricShiftWorking", "Vardiya Takip"),
                ("ELEKTRIK", "CumulativeElectricityConsumption", "Tüketim Takip"),
                ("ELEKTRIK", "ElectricMeterLocation", "Sayaç Takip"),
            
                // ================= OTOMASYON =================
                ("OTOMASYON", "General", "Otomasyon"),
                ("OTOMASYON", "PlcMachine", "Otomasyon"),
                ("OTOMASYON", "PlcTags", "Otomasyon"),
            
                // ================= AYARLAR =================
                ("AYARLAR", "Users", "Kullanıcı Listesi"),
                ("AYARLAR", "Roles", "Rol Listesi"),
                ("AYARLAR", "Shifts", "Vardiya Listesi")
            };

            var list = new List<DB_Permission>();

            foreach (var m in modules)
            {
                list.AddRange(new[]
                {
            new DB_Permission
            {
                Module = m.Module,
                Controller = m.Controller,
                Action = "View",
                Description = $"{m.Description} - Görüntüleme"
            },
            new DB_Permission
            {
                Module = m.Module,
                Controller = m.Controller,
                Action = "Add",
                Description = $"{m.Description} - Ekleme"
            },
            new DB_Permission
            {
                Module = m.Module,
                Controller = m.Controller,
                Action = "Update",
                Description = $"{m.Description} - Güncelleme"
            },
            new DB_Permission
            {
                Module = m.Module,
                Controller = m.Controller,
                Action = "Delete",
                Description = $"{m.Description} - Silme"
            }
        });
            }

            await context.Db_Permission.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }
    }
}
