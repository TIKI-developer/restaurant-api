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
                .HasKey(x => x.Client);
            builder
                .HasIndex(x => x.Client)
                .IsUnique();
            builder
                .HasMany(x => x.Dishes);
        }
    }
}
