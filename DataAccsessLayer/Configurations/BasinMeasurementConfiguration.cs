using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BasinMeasurementConfiguration : IEntityTypeConfiguration<DB_BasinMeasurement>
    {
        public void Configure(EntityTypeBuilder<DB_BasinMeasurement> builder)
        {
            builder
            .HasOne(x => x.Basin)
            .WithMany(x => x.Measurements)
            .HasForeignKey(x => x.BasinId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
