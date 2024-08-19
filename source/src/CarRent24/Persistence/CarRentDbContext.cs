using CarRent24.Common;
using CarRent24.Feature.Cars.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarRent24.Persistence
{
    public class CarRentDbContext : DbContext, IUnitOfWork
    {
        public CarRentDbContext(DbContextOptions options) : base(options) { }

        public void CommitChanges()
        {
            SaveChanges();           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration()); 

            // Autoregistration, no changes needed this way
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}