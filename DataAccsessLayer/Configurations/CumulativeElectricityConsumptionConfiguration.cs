using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class CumulativeElectricityConsumptionConfiguration : IEntityTypeConfiguration<DB_CumulativeElectricityConsumption>
    {
        public void Configure(EntityTypeBuilder<DB_CumulativeElectricityConsumption> builder)
        {
            builder
            .HasOne(x => x.ElectricMeterLocation)
            .WithMany(x => x.CumulativeElectricityConsumption)
            .HasForeignKey(x => x.ElectricMeterLocationId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
         .HasOne(x => x.Shift)
            .WithMany(x => x.CumulativeElectricityConsumption)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
        .HasOne(x => x.AppUser)
            .WithMany(x => x.CumulativeElectricityConsumption)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.CumulativeElectricityConsumption)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
