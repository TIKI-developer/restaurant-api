using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Cart;
using Restaurant.Domain.User.Client;


namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<CartModel>
    {
        public void Configure(EntityTypeBuilder<CartModel> builder)
        {
            builder
                .HasKey(x => x.ClientId);
            builder
                .HasOne(c => c.Client)
                .WithOne(c => c.Cart)
                .HasForeignKey<CartModel>(c => c.ClientId);
        }
    }
}
