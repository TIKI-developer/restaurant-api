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
                .HasKey(x => x.Id);
            builder
                .HasIndex(x => x.Id)
                .IsUnique();
            builder
                .HasMany(x => x.Categories)
                .WithMany(x => x.Dishes);
        }
    }
}
