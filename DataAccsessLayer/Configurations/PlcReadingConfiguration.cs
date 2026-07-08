using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class PlcReadingConfiguration : IEntityTypeConfiguration<DB_PlcReading>
    {
        public void Configure(EntityTypeBuilder<DB_PlcReading> builder)
        {
            builder
                .HasOne(x => x.PlcTag)
                .WithMany(x => x.Readings)
                .HasForeignKey(x => x.PlcTagId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
               .HasIndex(x => x.ReadingTime);
        }
    }
}
