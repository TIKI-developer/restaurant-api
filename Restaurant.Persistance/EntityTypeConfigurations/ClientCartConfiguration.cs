using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.User.Client;


namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class ClientCartConfiguration : IEntityTypeConfiguration<ClientModel.CartModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel.CartModel> builder)
        {
            builder
                .HasNoKey();
            builder
                .HasMany(c => c.Dishes)
                .WithMany(d => d.Carts);
        }
    }
}
