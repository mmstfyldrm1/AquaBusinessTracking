using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class StarchAnalysisHeadingConfiguration : IEntityTypeConfiguration<DB_StarchAnalysisHeading>
    {
        public void Configure(EntityTypeBuilder<DB_StarchAnalysisHeading> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.StarchAnalysisHeadings)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.StarchAnalysisHeadings)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.StarchAnalysisHeadings)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
