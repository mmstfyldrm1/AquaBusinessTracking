using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<DB_RolePermission>
    {
        public void Configure(EntityTypeBuilder<DB_RolePermission> builder)
        {
            // Composite Key
            builder
                .HasKey(x => new { x.RoleId, x.PermissionId });

            // Role ilişkisi
            builder
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Permission ilişkisi
            builder
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasKey(x => new { x.RoleId, x.PermissionId });
        }
    }
}
