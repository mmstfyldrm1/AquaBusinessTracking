using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WarehouseRequestWaitConfiguration : IEntityTypeConfiguration<DB_WarehouseRequestWait>
    {
        public void Configure(EntityTypeBuilder<DB_WarehouseRequestWait> builder)
        {
            builder
               .HasOne(x => x.Department)
               .WithMany(x => x.WarehouseRequestWaits)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(x => x.AppUser)
             .WithMany(x => x.WarehouseRequestWaits)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.WarehouseRequestWaits)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
