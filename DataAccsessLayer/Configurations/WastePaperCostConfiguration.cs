using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WastePaperCostConfiguration : IEntityTypeConfiguration<DB_WastePaperCost>
    {
        public void Configure(EntityTypeBuilder<DB_WastePaperCost> builder)
        {
            builder
             .HasOne(x => x.Department)
             .WithMany(x => x.WastePaperCosts)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);


            builder
             .HasOne(x => x.AppUser)
             .WithMany(x => x.WastePaperCosts)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(x => x.Shift)
             .WithMany(x => x.WastePaperCosts)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
