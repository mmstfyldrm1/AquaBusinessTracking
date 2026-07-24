using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class RawMaterialIntakeConfiguration : IEntityTypeConfiguration<DB_RawMaterialIntake>
    {
        public void Configure(EntityTypeBuilder<DB_RawMaterialIntake> builder)
        {
            builder
           .HasOne(x => x.Shift)
           .WithMany(x => x.RawMaterialIntakes)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.RawMaterialIntakes)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.RawMaterialIntakes)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
