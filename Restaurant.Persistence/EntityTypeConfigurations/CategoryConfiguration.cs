using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Categories");
            builder
                .HasMany(e => e.Dishes)
                .WithMany(e => e.Categories);
            builder
                .OwnsOne(e => e.Content, c =>
                {
                    c.WithOwner();
                });
        }
    }
}
