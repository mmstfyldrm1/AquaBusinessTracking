using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BasinConfiguration : IEntityTypeConfiguration<DB_Basin>
    {
        public void Configure(EntityTypeBuilder<DB_Basin> builder)
        {
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Basins)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppUser)
                   .WithMany(x => x.Basins)
                   .HasForeignKey(x => x.AppUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Shift)
                   .WithMany(x => x.Basins)
                   .HasForeignKey(x => x.ShiftId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
