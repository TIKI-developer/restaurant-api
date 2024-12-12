using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
                .HasIndex(x => x.UserId);
            builder
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(c => c.UserId);
            builder
                .HasMany(e => e.Items)
                .WithOne(e => e.Cart);
        }
    }
}
