using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class TestDetailConfiguration : IEntityTypeConfiguration<DB_TestDetail>
    {
        public void Configure(EntityTypeBuilder<DB_TestDetail> builder)
        {
            builder
            .HasOne(x => x.TestHeader)
            .WithMany(x => x.TestDetails)
            .HasForeignKey(x => x.TestHeaderId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
