using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Promotion;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<PromotionModel>
    {
        public void Configure(EntityTypeBuilder<PromotionModel> builder)
        {
            builder
                .HasKey(p => p.Id);
            builder
                .HasIndex(p => p.Id)
                .IsUnique();
        }
    }
}
