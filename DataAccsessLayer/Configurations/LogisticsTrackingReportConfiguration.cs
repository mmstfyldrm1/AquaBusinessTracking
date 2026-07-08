using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class LogisticsTrackingReportConfiguration : IEntityTypeConfiguration<DB_LogisticsTrackingReport>
    {
        public void Configure(EntityTypeBuilder<DB_LogisticsTrackingReport> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.LogisticsTrackingReports)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.LogisticsTrackingReports)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.LogisticsTrackingReports)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
