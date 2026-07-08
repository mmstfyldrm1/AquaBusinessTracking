using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class FavoriteMenuItemConfiguration : IEntityTypeConfiguration<DB_FavoriteMenuItem>
    {
        public void Configure(EntityTypeBuilder<DB_FavoriteMenuItem> builder)
        {
            builder.HasOne(x => x.AppUser)
               .WithMany(x => x.FavoriteMenuItems)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Permission)
              .WithMany(x => x.FavoriteMenuItems)
              .HasForeignKey(x => x.ModuleId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
