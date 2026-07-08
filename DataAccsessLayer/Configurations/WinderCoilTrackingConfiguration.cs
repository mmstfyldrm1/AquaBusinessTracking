using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WinderCoilTrackingConfiguration : IEntityTypeConfiguration<DB_WinderCoilTracking>
    {
        public void Configure(EntityTypeBuilder<DB_WinderCoilTracking> builder)
        {

            builder.HasOne(x => x.Department)
               .WithMany(x => x.WinderCoilTrackings)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(x => x.AppUser)
             .WithMany(x => x.WinderCoilTrackings)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);



            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.WinderCoilTrackings)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
