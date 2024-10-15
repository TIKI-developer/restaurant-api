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
