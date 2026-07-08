using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BufferProductionConfiguration : IEntityTypeConfiguration<DB_BufferProduction>
    {
        public void Configure(EntityTypeBuilder<DB_BufferProduction> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.BufferProduction)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(x => x.AppUser)
             .WithMany(x => x.BufferProduction)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.BufferProduction)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
