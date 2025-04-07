using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder
                .ToTable("Promotions");
            builder
                .OwnsOne(e => e.Content, c =>
                {
                    c.WithOwner();
                });
        }
    }
}
