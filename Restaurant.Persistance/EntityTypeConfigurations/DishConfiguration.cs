using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasMany(x => x.Categories).WithMany(x => x.Dishes);
        }
    }
}
