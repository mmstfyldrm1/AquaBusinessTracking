using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class SentezAllDataConfiguration : IEntityTypeConfiguration<DB_SentezAllData>
    {
        public void Configure(EntityTypeBuilder<DB_SentezAllData> builder)
        {

            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.SentezAllData)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.SentezAllData)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.SentezAllData)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
