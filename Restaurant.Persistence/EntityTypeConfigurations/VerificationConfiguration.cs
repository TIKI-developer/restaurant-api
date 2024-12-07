using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.User;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class VerificationConfiguration : IEntityTypeConfiguration<VerificationModel>
    {
        public void Configure(EntityTypeBuilder<VerificationModel> builder)
        {
            builder
                .HasKey(e => e.Number);

            builder
                .HasIndex(e => e.Number)
                .IsUnique();
            builder
                .Property(e => e.CanLogin)
                .HasDefaultValue(false);
        }
    }
}
