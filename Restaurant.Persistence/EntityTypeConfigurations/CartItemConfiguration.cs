using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartDishItem>
    {
        public void Configure(EntityTypeBuilder<CartDishItem> builder)
        {
            builder
                .ToTable("CartItem");
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
