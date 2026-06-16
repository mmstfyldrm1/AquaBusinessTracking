using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
