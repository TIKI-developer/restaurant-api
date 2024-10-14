using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;


namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId).IsUnique();
            builder.HasMany(x => x.Dishes);
        }
    }
}
