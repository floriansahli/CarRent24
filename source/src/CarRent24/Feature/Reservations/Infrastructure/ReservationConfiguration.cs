using CarRent24.Feature.Reservations.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent24.Feature.Reservations.Infrastructure
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.StartDate).IsRequired();
            builder.Property(r => r.EndDate).IsRequired();
            builder.Property(r => r.TotalAmount).IsRequired();

            builder.HasOne(r => r.CarClass)
                .WithMany();

            builder.HasOne(r => r.Customer)
                .WithMany();

        }
    }
}
