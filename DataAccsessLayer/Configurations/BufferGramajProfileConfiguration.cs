using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class BufferGramajProfileConfiguration : IEntityTypeConfiguration<DB_BufferGramajProfile>
    {
        public void Configure(EntityTypeBuilder<DB_BufferGramajProfile> builder)
        {
            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.BufferGramajProfiles)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);



            builder
           .HasOne(x => x.AppUser)
           .WithMany(x => x.BufferGramajProfiles)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.BufferGramajProfiles)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
