using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class PurificationChemicalsConsumptionConfiguration : IEntityTypeConfiguration<DB_PurificationChemicalsConsumption>
    {
        public void Configure(EntityTypeBuilder<DB_PurificationChemicalsConsumption> builder)
        {

            builder
           .HasOne(x => x.Shift)
           .WithMany(x => x.PurificationChemicalsConsumptions)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder
           .HasOne(x => x.Shift)
           .WithMany(x => x.PurificationChemicalsConsumptions)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder
           .HasOne(x => x.Shift)
           .WithMany(x => x.PurificationChemicalsConsumptions)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
