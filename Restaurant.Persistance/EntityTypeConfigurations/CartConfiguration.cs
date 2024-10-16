using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Cart;


namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<UserCartModel>
    {
        public void Configure(EntityTypeBuilder<UserCartModel> builder)
        {
            builder
                .HasKey(c => c.ClientId);
            builder
                .HasIndex(c => c.ClientId)
                .IsUnique();
            builder
                .HasMany(c => c.Dishes)
                .WithMany(d => d.Carts);
        }
    }
}
