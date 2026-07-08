using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class ElectricMotorTrackingConfiguration : IEntityTypeConfiguration<DB_ElectricMotorTracking>
    {
        public void Configure(EntityTypeBuilder<DB_ElectricMotorTracking> builder)
        {

            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.ElectricMotorTrackings)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.ElectricMotorTrackings)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.ElectricMotorTrackings)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
