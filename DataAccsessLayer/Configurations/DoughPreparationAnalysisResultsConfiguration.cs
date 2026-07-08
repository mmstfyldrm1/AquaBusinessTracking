using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class DoughPreparationAnalysisResultsConfiguration : IEntityTypeConfiguration<DB_DoughPreparationAnalysisResults>
    {
        public void Configure(EntityTypeBuilder<DB_DoughPreparationAnalysisResults> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.DoughPreparationAnalysisResults)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.DoughPreparationAnalysisResults)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
          .HasOne(x => x.AppUser)
          .WithMany(x => x.DoughPreparationAnalysisResults)
          .HasForeignKey(x => x.AppUserId)
          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
