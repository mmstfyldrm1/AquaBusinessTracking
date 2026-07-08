using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class KazanChemicalsHeadConfiguration : IEntityTypeConfiguration<DB_KazanChemicalsHead>
    {
        public void Configure(EntityTypeBuilder<DB_KazanChemicalsHead> builder)
        {

            builder
               .HasOne(x => x.AppUser)
               .WithMany(x => x.KazanChemicalsHead)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(x => x.Department)
               .WithMany(x => x.KazanChemicalsHead)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.KazanChemicalsHead)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
