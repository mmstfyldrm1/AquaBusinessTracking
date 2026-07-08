using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WinderCoilLengthControlConfiguration : IEntityTypeConfiguration<DB_WinderCoilLengthControl>
    {
        public void Configure(EntityTypeBuilder<DB_WinderCoilLengthControl> builder)
        {
            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.WinderCoilLengthControl)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WinderCoilLengthControl)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.WinderCoilLengthControl)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
