namespace BusinessLayer.Reports.@abstract
{
    public interface IReportFileService
    {
        Task<byte[]> ReadFileAsync(string fileName);
    }
}
