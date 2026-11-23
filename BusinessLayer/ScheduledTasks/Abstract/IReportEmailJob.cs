namespace BusinessLayer.ScheduledTasks.Abstract
{
    public interface IReportEmailJob
    {
        Task SendDailyTestReportAsync(List<string> emailAddresses);

        Task SendDailyMachineReportAsync();
    }
}
