using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class MassWasteBalanceConfiguration : IEntityTypeConfiguration<DB_MassWasteBalance>
    {
        public void Configure(EntityTypeBuilder<DB_MassWasteBalance> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.MassWasteBalance)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.MassWasteBalance)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.MassWasteBalance)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
