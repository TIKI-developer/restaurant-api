using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(e => e.PhoneNumber)
                .IsUnique();
            builder
                .Property(e => e.PhoneNumber)
                .HasMaxLength(15);
            builder
                .HasOne(c => c.Cart)
                .WithOne(c => c.User);
            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.User);
            builder
                .OwnsOne(c => c.Profile, profile =>
                {
                    profile.WithOwner();
                    profile.OwnsOne(p => p.Address, address =>
                    {
                        address.WithOwner();
                    });
                    profile
                        .Property(e => e.Name)
                        .HasMaxLength(50);
                });
        }
    }
}
