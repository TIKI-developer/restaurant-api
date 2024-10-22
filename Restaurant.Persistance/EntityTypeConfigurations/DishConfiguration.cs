using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Dish;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class DishConfiguration : IEntityTypeConfiguration<DishModel>
    {
        public void Configure(EntityTypeBuilder<DishModel> builder)
        {
            builder
                .HasKey(d => d.Id);
            builder
                .HasIndex(d => d.Id)
                .IsUnique();
            builder
                .HasMany(d => d.Categories)
                .WithMany(c => c.Dishes);
            builder
                .HasMany(d => d.Carts)
                .WithMany(c => c.Dishes);
            builder
                .HasMany(d => d.Orders)
                .WithMany(o => o.Dishes);
        }
    }
}
