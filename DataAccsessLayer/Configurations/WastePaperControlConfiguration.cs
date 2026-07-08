using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WastePaperControlConfiguration : IEntityTypeConfiguration<DB_WastePaperControl>
    {
        public void Configure(EntityTypeBuilder<DB_WastePaperControl> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.WastePaperControls)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.WastePaperControls)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(x => x.Department)
              .WithMany(x => x.WastePaperControls)
              .HasForeignKey(x => x.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
