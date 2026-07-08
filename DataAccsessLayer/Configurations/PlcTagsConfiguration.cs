using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class PlcTagsConfiguration : IEntityTypeConfiguration<DB_PlcTags>
    {
        public void Configure(EntityTypeBuilder<DB_PlcTags> builder)
        {
            builder
                .HasOne(x => x.Machine)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasIndex(x => x.MachineId);
        }
    }
}
