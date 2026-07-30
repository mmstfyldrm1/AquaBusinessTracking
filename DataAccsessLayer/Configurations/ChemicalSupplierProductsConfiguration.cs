using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class ChemicalSupplierProductsConfiguration : IEntityTypeConfiguration<DB_ChemicalSupplierProducts>
    {
        public void Configure(EntityTypeBuilder<DB_ChemicalSupplierProducts> builder)
        {
            builder
              .HasOne(x => x.AppUser)
              .WithMany(x => x.ChemicalSupplierProducts)
              .HasForeignKey(x => x.AppUserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(x => x.Department)
               .WithMany(x => x.ChemicalSupplierProducts)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.ChemicalSupplierProducts)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
