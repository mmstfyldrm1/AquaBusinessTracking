using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class IncomingGoodsTrackingConfiguration : IEntityTypeConfiguration<DB_IncomingGoodsTracking>
    {
        public void Configure(EntityTypeBuilder<DB_IncomingGoodsTracking> builder)
        {
            builder
         .HasOne(x => x.Shift)
         .WithMany(x => x.IncomingGoodsTracking)
         .HasForeignKey(x => x.ShiftId)
         .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.IncomingGoodsTracking)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.IncomingGoodsTracking)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
