using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class KazanEnergyConsumptionConfiguration : IEntityTypeConfiguration<DB_KazanEnergyConsumption>
    {
        public void Configure(EntityTypeBuilder<DB_KazanEnergyConsumption> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.KazanEnergyConsumption)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(x => x.AppUser)
             .WithMany(x => x.KazanEnergyConsumption)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.KazanEnergyConsumption)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
