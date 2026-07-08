using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class KazanDailyShiftMonitoringConfiguration : IEntityTypeConfiguration<DB_KazanDailyShiftMonitoring>
    {
        public void Configure(EntityTypeBuilder<DB_KazanDailyShiftMonitoring> builder)
        {

            builder
           .HasOne(x => x.Shift)
           .WithMany(x => x.KazanDailyShiftMonitoring)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.KazanDailyShiftMonitoring)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.KazanDailyShiftMonitoring)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
