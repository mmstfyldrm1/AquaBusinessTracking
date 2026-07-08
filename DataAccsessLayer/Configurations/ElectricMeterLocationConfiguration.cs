using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class ElectricMeterLocationConfiguration : IEntityTypeConfiguration<DB_ElectricMeterLocation>
    {
        public void Configure(EntityTypeBuilder<DB_ElectricMeterLocation> builder)
        {
            builder
    .HasOne(x => x.Shift)
    .WithMany(x => x.ElectricMeterLocation)
    .HasForeignKey(x => x.ShiftId)
    .OnDelete(DeleteBehavior.Restrict);


            builder
     .HasOne(x => x.AppUser)
     .WithMany(x => x.ElectricMeterLocation)
     .HasForeignKey(x => x.AppUserId)
     .OnDelete(DeleteBehavior.Restrict);


            builder
        .HasOne(x => x.Department)
        .WithMany(x => x.ElectricMeterLocation)
        .HasForeignKey(x => x.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
