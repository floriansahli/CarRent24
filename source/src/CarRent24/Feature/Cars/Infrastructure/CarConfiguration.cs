using CarRent24.Feature.Cars.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent24.Feature.Cars.Infrastructure
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        // DB Configuration
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(256);


            builder.HasData(
                new Car() { Name = "Car 1", },
                new Car() { Name = "Car 2", },
                new Car() { Name = "Car 3", });
        }
    }
}