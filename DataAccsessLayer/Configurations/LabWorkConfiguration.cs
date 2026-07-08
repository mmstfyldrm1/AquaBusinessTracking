using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class LabWorkConfiguration : IEntityTypeConfiguration<DB_LabWork>
    {
        public void Configure(EntityTypeBuilder<DB_LabWork> builder)
        {
            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.LabWorks)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.LabWorks)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.LabWorks)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
