using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders");
            builder
                .HasOne(o => o.User)
                .WithMany(c => c.Orders);
            builder
                .HasOne(o => o.Branch)
                .WithMany(b => b.Orders);
            builder
                .HasMany(e => e.Items)
                .WithOne(e => e.Order);
            builder
                .OwnsOne(e => e.Address);
        }
    }
}
