using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class ShipmentOrderPlanDetailConfiguration : IEntityTypeConfiguration<DB_ShipmentOrderPlanDetail>
    {
        public void Configure(EntityTypeBuilder<DB_ShipmentOrderPlanDetail> builder)
        {
            builder
            .HasOne(x => x.ShipmentOrderPlan)
            .WithMany(x => x.ShipmentOrderPlanDetail)
            .HasForeignKey(x => x.ShipmentPlanId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
