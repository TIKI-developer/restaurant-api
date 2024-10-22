using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Order;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder
                .HasKey(o => o.Id);
            builder
                .HasIndex(o => o.Id)
                .IsUnique();
            builder
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders);
            builder
                .HasMany(o => o.Dishes)
                .WithMany(d => d.Orders);
        }
    }
}
