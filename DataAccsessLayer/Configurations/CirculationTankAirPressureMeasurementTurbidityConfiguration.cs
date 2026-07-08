using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class CirculationTankAirPressureMeasurementTurbidityConfiguration : IEntityTypeConfiguration<DB_CirculationTankAirPressureMeasurementTurbidity>
    {
        public void Configure(EntityTypeBuilder<DB_CirculationTankAirPressureMeasurementTurbidity> builder)
        {
            builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.CirculationTankAirPressureMeasurementTurbidities)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);



            builder
           .HasOne(x => x.AppUser)
           .WithMany(x => x.CirculationTankAirPressureMeasurementTurbidities)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);


            builder
            .HasOne(x => x.Department)
            .WithMany(x => x.CirculationTankAirPressureMeasurementTurbidities)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
