using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccsessLayer
{
    public class AquaBusinessTrackingContextFactory : IDesignTimeDbContextFactory<AquaBusinessTrackingContext>
    {
        public AquaBusinessTrackingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AquaBusinessTrackingContext>();

            optionsBuilder.UseSqlServer(
                "Server=.;Database=AquaDB;Trusted_Connection=True;TrustServerCertificate=True");

            return new AquaBusinessTrackingContext(optionsBuilder.Options);
        }
    }
}
