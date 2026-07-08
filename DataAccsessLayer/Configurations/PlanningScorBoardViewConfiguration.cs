using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class PlanningScorBoardViewConfiguration : IEntityTypeConfiguration<DB_PlanningScorBoardView>
    {
        public void Configure(EntityTypeBuilder<DB_PlanningScorBoardView> builder)
        {
            builder.HasOne(x => x.Department)
                .WithMany(x => x.PlanningScorBoardView)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppUser)
                   .WithMany(x => x.PlanningScorBoardView)
                   .HasForeignKey(x => x.AppUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Shift)
                   .WithMany(x => x.PlanningScorBoardView)
                   .HasForeignKey(x => x.ShiftId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
