using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class VechileFuelLogsConfiguration : IEntityTypeConfiguration<DB_VechileFuelLogs>
    {
        public void Configure(EntityTypeBuilder<DB_VechileFuelLogs> builder)
        {
            builder
             .HasOne(x => x.Shift)
             .WithMany(x => x.VechileFuelLogs)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.VechileFuelLogs)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
             .HasOne(x => x.Department)
             .WithMany(x => x.VechileFuelLogs)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
