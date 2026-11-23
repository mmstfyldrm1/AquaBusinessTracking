
using BusinessLayer.Abstract.Reports;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.DTOs.Reports;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete.Reports
{
    public class MachineDailyReportManager : IMachineDailyReportService
    {
        private const int MachineId = 6;

        private readonly IUnitOfWork _unitOfWork;

        public MachineDailyReportManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MachineDailyReportDto?> GetDailyReportAsync(
            DateTime reportDate)
        {
            reportDate = reportDate.Date;

            var closingStart = reportDate.AddDays(1);
            var closingEnd = closingStart.AddHours(1);

            var machine = await _unitOfWork
                .Repository<DB_PlcMachine>()
                .TGetById(MachineId);

            if (machine == null)
                return null;

            var tags = await _unitOfWork
                .Repository<DB_PlcTags>()
                .TGetAll(x =>
                    x.MachineId == MachineId &&
                    x.IsActive);

            var tagIds = tags.Select(x => x.RecId).ToList();

            var readings = await _unitOfWork
                .Repository<DB_PlcReading>()
                .TGetAll(x =>
                    tagIds.Contains(x.PlcTagId) &&
                    x.ReadingTime >= closingStart &&
                    x.ReadingTime < closingEnd);

            var firstReadings = readings
                .GroupBy(x => x.PlcTagId)
                .ToDictionary(
                    x => x.Key,
                    x => x.OrderBy(r => r.ReadingTime).First()
                );

            var report = new MachineDailyReportDto
            {
                MachineId = machine.RecId,
                MachineName = machine.Name,
                ReportDate = reportDate
            };

            foreach (var tag in tags)
            {
                firstReadings.TryGetValue(tag.RecId, out var reading);

                report.Items.Add(new MachineDailyReportItemDto
                {
                    TagId = tag.RecId,
                    TagName = tag.TagName,
                    DisplayName = tag.DisplayName,
                    Unit = tag.Unit,
                    Value = reading?.Value,
                    ReadingTime = reading?.ReadingTime
                });
            }

            return report;
        }
    }
}
