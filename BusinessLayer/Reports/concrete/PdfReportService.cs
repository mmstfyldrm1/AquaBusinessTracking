using BusinessLayer.Reports.@abstract;
using DTOLayer.DTOs.Reports;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Globalization;

namespace BusinessLayer.Reports.concrete
{
    public class PdfReportService : IPdfReportService
    {
        public byte[] GenerateTestPdf()
        {
            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.Header()
                        .Text("Aqua MES - Test Raporu")
                        .FontSize(20)
                        .Bold();

                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            column.Item().Text("PDF oluşturma testi başarılı.");
                            column.Item().Text(
                                $"Oluşturulma Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}");
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text("Aqua MES")
                        .FontSize(9);
                });
            }).GeneratePdf();

            return pdf;
        }


        public byte[] GenerateMachineDailyReportPdf(MachineDailyReportDto report)
        {
            var culture = new CultureInfo("tr-TR");

            return Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(35);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Column(column =>
                    {
                        column.Item()
                            .Text("GÜNLÜK MAKİNE ÜRETİM RAPORU")
                            .FontSize(18)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item()
                            .PaddingTop(5)
                            .Text(report.MachineName)
                            .FontSize(13)
                            .SemiBold();

                        column.Item()
                            .Text($"Rapor Tarihi: {report.ReportDate:dd.MM.yyyy}");

                        column.Item()
                            .PaddingTop(10)
                            .LineHorizontal(1)
                            .LineColor(Colors.Grey.Lighten1);
                    });

                    page.Content().PaddingVertical(20).Column(column =>
                    {
                        column.Item()
                            .Text("Makine Verileri")
                            .FontSize(13)
                            .Bold();

                        column.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                            });

                            table.Header(header =>
                            {
                                header.Cell()
                                    .Background(Colors.Blue.Darken2)
                                    .Padding(6)
                                    .Text("Parametre")
                                    .FontColor(Colors.White)
                                    .SemiBold();

                                header.Cell()
                                    .Background(Colors.Blue.Darken2)
                                    .Padding(6)
                                    .Text("Değer")
                                    .FontColor(Colors.White)
                                    .SemiBold();

                                header.Cell()
                                    .Background(Colors.Blue.Darken2)
                                    .Padding(6)
                                    .Text("Birim")
                                    .FontColor(Colors.White)
                                    .SemiBold();
                            });

                            foreach (var item in report.Items)
                            {
                                var valueText = item.Value.HasValue
                                    ? item.Value.Value.ToString("N2", culture)
                                    : "Eksik Veri";

                                table.Cell()
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Grey.Lighten2)
                                    .Padding(6)
                                    .Text(item.DisplayName);

                                table.Cell()
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Grey.Lighten2)
                                    .Padding(6)
                                    .Text(valueText);

                                table.Cell()
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Grey.Lighten2)
                                    .Padding(6)
                                    .Text(item.Unit);
                            }
                        });

                        if (report.HasMissingData)
                        {
                            column.Item()
                                .PaddingTop(15)
                                .Background(Colors.Orange.Lighten4)
                                .Padding(10)
                                .Text("Uyarı: Bazı parametreler için kapanış verisi bulunamadı.")
                                .FontColor(Colors.Orange.Darken3);
                        }

                        column.Item()
                            .PaddingTop(20)
                            .Text($"Rapor oluşturulma zamanı: {DateTime.Now:dd.MM.yyyy HH:mm}")
                            .FontSize(8)
                            .FontColor(Colors.Grey.Darken1);
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text("AquaBusinessTracking - Günlük Makine Raporu")
                        .FontSize(8)
                        .FontColor(Colors.Grey.Darken1);
                });
            }).GeneratePdf();
        }



    }
}