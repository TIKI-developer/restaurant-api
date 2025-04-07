using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
    {
        public void Configure(EntityTypeBuilder<Verification> builder)
        {
            builder
                .HasKey(e => e.Number);
            builder
                .HasIndex(e => e.Number)
                .IsUnique();
            builder
                .Property(e => e.CanLogin)
                .HasDefaultValue(false);
            builder
                .OwnsOne(e => e.Timestamps, ts =>
                {
                    ts.WithOwner();
                });
        }
    }
}
