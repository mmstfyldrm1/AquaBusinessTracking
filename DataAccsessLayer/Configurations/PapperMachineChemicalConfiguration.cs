using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class PapperMachineChemicalConfiguration : IEntityTypeConfiguration<DB_PapperMachineChemical>
    {
        public void Configure(EntityTypeBuilder<DB_PapperMachineChemical> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.PapperMachineChemicals)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.AppUser)
            .WithMany(x => x.PapperMachineChemicals)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.PapperMachineChemicals)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
