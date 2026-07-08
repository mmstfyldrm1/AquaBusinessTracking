using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class SalesScaleConfiguration : IEntityTypeConfiguration<DB_SalesScale>
    {
        public void Configure(EntityTypeBuilder<DB_SalesScale> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.SalesScales)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.SalesScales)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.SalesScales)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
