using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.User;
using Restaurant.Domain.User.Admin;
using Restaurant.Domain.User.Client;

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
                .HasIndex(u => u.Number)
                .IsUnique();
            builder
                .HasDiscriminator<string>("User Type")
                .HasValue<ClientModel>("Client")
                .HasValue<AdminModel>("Admin");
        }
    }
}
