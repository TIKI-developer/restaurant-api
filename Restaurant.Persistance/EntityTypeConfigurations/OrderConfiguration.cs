using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasOne(x => x.Client);
        }
    }
}
