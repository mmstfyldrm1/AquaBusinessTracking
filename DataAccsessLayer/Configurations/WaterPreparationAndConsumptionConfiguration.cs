using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WaterPreparationAndConsumptionConfiguration : IEntityTypeConfiguration<DB_WaterPreparationAndConsumption>
    {
        public void Configure(EntityTypeBuilder<DB_WaterPreparationAndConsumption> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.WaterPreparationAndConsumption)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.WaterPreparationAndConsumption)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
             .HasOne(x => x.Department)
             .WithMany(x => x.WaterPreparationAndConsumption)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
