using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BoilerOperationandChemicalConsumptionConfiguration : IEntityTypeConfiguration<DB_BoilerOperationandChemicalConsumption>
    {
        public void Configure(EntityTypeBuilder<DB_BoilerOperationandChemicalConsumption> builder)
        {

            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.BoilerOperationandChemicalConsumption)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.BoilerOperationandChemicalConsumption)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.BoilerOperationandChemicalConsumption)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.ScalePlace)
                .WithMany()
                .HasForeignKey(x => x.ScalePlaceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
             .HasOne(x => x.KazanEnergyConsumption)
             .WithMany(x => x.BoilerOperationandChemicalConsumption)
             .HasForeignKey(x => x.ConsumptionPlaceId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
