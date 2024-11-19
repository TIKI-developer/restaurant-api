using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Order;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
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
