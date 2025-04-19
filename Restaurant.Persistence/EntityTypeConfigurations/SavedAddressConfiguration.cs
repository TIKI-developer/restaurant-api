using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class SavedAddressConfiguration : IEntityTypeConfiguration<SavedAddress>
    {
        public void Configure(EntityTypeBuilder<SavedAddress> builder)
        {
            builder
                .ToTable("SavedAddresses");
            builder
                .Property(e => e.Name)
                .HasMaxLength(300);
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.SavedAddresses)
                .HasForeignKey(e => e.UserId);
            builder
                .OwnsOne(e => e.Address, a =>
                {
                    a.WithOwner();
                });
        }
    }
}
