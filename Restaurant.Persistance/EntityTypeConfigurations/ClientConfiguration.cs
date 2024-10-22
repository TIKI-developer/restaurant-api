using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.User.Client;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder
                .HasOne(c => c.Cart)
                .WithOne(c => c.Client);
            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client);
            builder
                .OwnsOne(c => c.Profile, profile => {
                    profile.WithOwner();
                });
        }
    }
}
