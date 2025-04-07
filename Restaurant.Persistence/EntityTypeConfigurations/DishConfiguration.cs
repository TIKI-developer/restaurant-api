using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder
                .HasMany(d => d.Categories)
                .WithMany(c => c.Dishes);
            builder
                .OwnsOne(e => e.Content, c =>
                {
                    c.WithOwner();
                });
        }
    }
}
