using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class ElectricShiftWorkConfiguration : IEntityTypeConfiguration<DB_ElectricShiftWork>
    {
        public void Configure(EntityTypeBuilder<DB_ElectricShiftWork> builder)
        {
            builder
             .HasOne(x => x.Shift)
             .WithMany(x => x.ElectricShiftWork)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.ElectricShiftWork)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.ElectricShiftWork)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
