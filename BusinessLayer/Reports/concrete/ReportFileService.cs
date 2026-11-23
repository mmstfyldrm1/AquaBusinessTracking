using BusinessLayer.Reports.@abstract;

namespace BusinessLayer.Reports
{
    public class ReportFileService : IReportFileService
    {
        private readonly string _reportDirectory;

        public ReportFileService()
        {
            _reportDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "ReportFiles");
        }

        public async Task<byte[]> ReadFileAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Dosya adı boş olamaz.");

            if (Path.GetFileName(fileName) != fileName)
                throw new UnauthorizedAccessException("Geçersiz dosya yolu.");

            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            if (extension != ".pdf" && extension != ".xlsx")
                throw new UnauthorizedAccessException("Desteklenmeyen dosya türü.");

            var fullPath = Path.GetFullPath(
                Path.Combine(_reportDirectory, fileName));

            var rootPath = Path.GetFullPath(_reportDirectory)
                .TrimEnd(Path.DirectorySeparatorChar)
                + Path.DirectorySeparatorChar;

            if (!fullPath.StartsWith(
                rootPath,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Geçersiz dosya konumu.");
            }

            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Rapor dosyası bulunamadı.");

            return await File.ReadAllBytesAsync(fullPath);
        }
    }
}