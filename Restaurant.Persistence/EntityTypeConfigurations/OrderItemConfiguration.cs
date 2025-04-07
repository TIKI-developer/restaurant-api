using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderDishItem>
    {
        public void Configure(EntityTypeBuilder<OrderDishItem> builder)
        {
            builder
                .ToTable("OrderDishItems");

            builder.HasKey(e => new { e.OrderId, e.DishId });

            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId);

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
