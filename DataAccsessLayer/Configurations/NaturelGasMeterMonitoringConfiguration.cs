using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class NaturelGasMeterMonitoringConfiguration : IEntityTypeConfiguration<DB_NaturelGasMeterMonitoring>
    {
        public void Configure(EntityTypeBuilder<DB_NaturelGasMeterMonitoring> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.NaturelGasMeterMonitorings)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.NaturelGasMeterMonitorings)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.NaturelGasMeterMonitorings)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
