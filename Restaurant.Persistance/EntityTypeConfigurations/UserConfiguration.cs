using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .HasIndex(x => x.Id).IsUnique();
            builder
                .HasMany(x => x.Orders);
            builder
                .HasIndex(x => x.Number)
                .IsUnique();
        }
    }
}
