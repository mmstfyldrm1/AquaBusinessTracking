using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BufferAnalysisReportConfiguration : IEntityTypeConfiguration<DB_BufferAnalysisReport>
    {
        public void Configure(EntityTypeBuilder<DB_BufferAnalysisReport> builder)
        {

            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.BufferAnalysisReports)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.BufferAnalysisReports)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.BufferAnalysisReports)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
