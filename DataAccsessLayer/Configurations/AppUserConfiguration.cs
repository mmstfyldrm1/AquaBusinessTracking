using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<DB_AppUser>
    {
        public void Configure(EntityTypeBuilder<DB_AppUser> builder)
        {
            builder
              .HasOne(x => x.Department)
              .WithMany(x => x.AppUsers)
              .HasForeignKey(x => x.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
