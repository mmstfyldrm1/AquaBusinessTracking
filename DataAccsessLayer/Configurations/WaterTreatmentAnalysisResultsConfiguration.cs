using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class WaterTreatmentAnalysisResultsConfiguration : IEntityTypeConfiguration<DB_WaterTreatmentAnalysisResults>
    {
        public void Configure(EntityTypeBuilder<DB_WaterTreatmentAnalysisResults> builder)
        {
            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.WaterTreatmentAnalysisResults)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WaterTreatmentAnalysisResults)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.WaterTreatmentAnalysisResults)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
