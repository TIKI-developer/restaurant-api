using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Dish;
using Restaurant.Domain.User.Client;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client);
            builder
                .OwnsOne(c => c.Cart, cart =>
                {
                    cart
                        .WithOwner();
                    cart
                        .HasOne<ClientModel>()
                        .WithOne()
                        .HasForeignKey<ClientModel>(client => client.Id);
                    cart.Ignore(c => c.Dishes);
                });
            //builder
            //    .OwnsOne(c => c.Profile, profile =>
            //    {
            //        profile.WithOwner();
            //    });
        }
    }
}
