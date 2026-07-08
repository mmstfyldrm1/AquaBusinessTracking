using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class MassWasteSupplierConfiguration : IEntityTypeConfiguration<DB_MassWasteSupplier>
    {
        public void Configure(EntityTypeBuilder<DB_MassWasteSupplier> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.MassWasteSupplier)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.MassWasteSupplier)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
             .HasOne(x => x.Department)
             .WithMany(x => x.MassWasteSupplier)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
