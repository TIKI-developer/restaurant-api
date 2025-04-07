using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable("Addresses");
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.UserId);
        }
    }
}
