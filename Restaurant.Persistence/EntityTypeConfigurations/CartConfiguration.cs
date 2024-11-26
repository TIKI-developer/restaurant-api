using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Cart;


namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<CartModel>
    {
        public void Configure(EntityTypeBuilder<CartModel> builder)
        {
            builder
                .HasKey(x => x.UserId);
            builder
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .HasForeignKey<CartModel>(c => c.UserId);

            builder
                .HasMany(e => e.Items)
                .WithOne(e => e.Cart);
        }
    }
}
