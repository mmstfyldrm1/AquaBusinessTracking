using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class MachineStopConfiguration : IEntityTypeConfiguration<DB_MachineStop>
    {
        public void Configure(EntityTypeBuilder<DB_MachineStop> builder)
        {
            builder
             .HasOne(x => x.Shift)
             .WithMany(x => x.MachineStop)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.MachineStop)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.MachineStop)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
