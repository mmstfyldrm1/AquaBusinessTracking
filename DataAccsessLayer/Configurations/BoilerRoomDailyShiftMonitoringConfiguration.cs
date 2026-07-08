using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BoilerRoomDailyShiftMonitoringConfiguration : IEntityTypeConfiguration<DB_BoilerRoomDailyShiftMonitoring>
    {
        public void Configure(EntityTypeBuilder<DB_BoilerRoomDailyShiftMonitoring> builder)
        {

            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.BoilerRoomDailyShiftMonitoring)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.BoilerRoomDailyShiftMonitoring)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.BoilerRoomDailyShiftMonitoring)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
