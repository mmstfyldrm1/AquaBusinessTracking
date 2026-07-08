using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class StarchAnalysisHeadingDetailConfiguration : IEntityTypeConfiguration<DB_StarchAnalysisHeadingDetail>
    {
        public void Configure(EntityTypeBuilder<DB_StarchAnalysisHeadingDetail> builder)
        {
            builder
            .HasOne(x => x.StarchAnalysisHeading)
            .WithMany(x => x.StarchAnalysisHeadingDetails)
            .HasForeignKey(x => x.StarchAnalysisHeadingId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
