using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class SteamConsumptionConfiguration : IEntityTypeConfiguration<DB_SteamConsumption>
    {
        public void Configure(EntityTypeBuilder<DB_SteamConsumption> builder)
        {
            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.SteamConsumptions)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.SteamConsumptions)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.SteamConsumptions)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
