using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class DoughPreparationConfiguration : IEntityTypeConfiguration<DB_DoughPreparation>
    {
        public void Configure(EntityTypeBuilder<DB_DoughPreparation> builder)
        {
            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.DoughPreparations)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.DoughPreparations)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);



            builder
               .HasOne(x => x.AppUser)
               .WithMany(x => x.DoughPreparations)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
