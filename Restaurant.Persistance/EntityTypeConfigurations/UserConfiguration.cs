using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.User;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder
                .HasKey(u => u.Id);
            builder
                .HasIndex(u => u.Id).IsUnique();
            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.Client);
            builder
                .HasIndex(u => u.Number)
                .IsUnique();
        }
    }
}
