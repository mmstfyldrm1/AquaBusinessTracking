using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class DailyShipmentPlanConfiguration : IEntityTypeConfiguration<DB_DailyShipmentPlan>
    {
        public void Configure(EntityTypeBuilder<DB_DailyShipmentPlan> builder)
        {
            builder
               .HasOne(x => x.Department)
               .WithMany(x => x.DailyShipmentPlans)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(x => x.AppUser)
             .WithMany(x => x.DailyShipmentPlans)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.DailyShipmentPlans)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
