using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccsessLayer
{
    public class AquaContextFactory : IDesignTimeDbContextFactory<AquaBusinessTrackingContext>
    {
        public AquaBusinessTrackingContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AquaBusinessTrackingContext>()
                .UseSqlServer("Server=10.154.210.63\\AQUAPP;Database=AquaDB;User Id=myildirim;Password=My123456*;TrustServerCertificate=True;")
                .Options;

            return new AquaBusinessTrackingContext(options);
        }
    }
}