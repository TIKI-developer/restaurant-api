using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Category;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .HasIndex(c => c.Id)
                .IsUnique();
            builder
                .HasMany(c => c.Dishes)
                .WithMany(c => c.Categories);
        }
    }
}
