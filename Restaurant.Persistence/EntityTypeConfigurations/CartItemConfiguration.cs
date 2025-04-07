using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder
                .HasKey(e => new { e.CartId, e.DishId });

            builder
                .HasOne(oi => oi.Cart)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.CartId);

            builder
                .HasOne(oi => oi.Dish)
                .WithMany()
                .HasForeignKey(oi => oi.DishId);

            builder
                .Property(oi => oi.Count)
                .HasDefaultValue(1);
        }
    }
}
