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
                .HasKey(x => x.Id);
            builder
                .HasIndex(x => x.Id)
                .IsUnique();
            builder
                .HasMany(x => x.Dishes)
                .WithMany(x => x.Categories);
        }
    }
}
