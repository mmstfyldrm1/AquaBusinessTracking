using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BoilerSteamFeedWaterCondensateDataConfiguration : IEntityTypeConfiguration<DB_BoilerSteamFeedWaterCondensateData>
    {
        public void Configure(EntityTypeBuilder<DB_BoilerSteamFeedWaterCondensateData> builder)
        {
            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.BoilerSteamFeedWaterCondensateData)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.BoilerSteamFeedWaterCondensateData)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
          .HasOne(x => x.Shift)
          .WithMany(x => x.BoilerSteamFeedWaterCondensateData)
          .HasForeignKey(x => x.ShiftId)
          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
