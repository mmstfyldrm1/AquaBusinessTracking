using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class ShipmentOrderPlanConfiguration : IEntityTypeConfiguration<DB_ShipmentOrderPlan>
    {
        public void Configure(EntityTypeBuilder<DB_ShipmentOrderPlan> builder)
        {
            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.ShipmentOrderPlan)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
               .HasOne(x => x.Shift)
               .WithMany(x => x.ShipmentOrderPlan)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);



            builder
               .HasOne(x => x.AppUser)
               .WithMany(x => x.ShipmentOrderPlan)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
