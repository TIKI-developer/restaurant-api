using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasMany(x => x.Dishes).WithMany(x => x.Categories);
        }
    }
}
