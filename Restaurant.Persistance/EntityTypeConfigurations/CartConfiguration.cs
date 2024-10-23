using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Cart;
using Restaurant.Domain.User.Client;


namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<CartModel>
    {
        public void Configure(EntityTypeBuilder<CartModel> builder)
        {
            builder
                .HasKey(x => x.ClientId);
            builder
                .HasOne(c => c.Client)
                .WithOne(c => c.Cart)
                .HasForeignKey<CartModel>(c => c.ClientId);
            builder
                .HasMany(c => c.Dishes)
                .WithMany(d => d.Carts)
                .UsingEntity<CartModelDishModel>(
                    cd =>
                        cd
                            .HasOne(cd => cd.Dish)
                            .WithMany(d => d.CartModelDishModels)
                            .HasForeignKey(cd => cd.DishId),
                    cd =>
                        cd
                            .HasOne(cd => cd.Cart)
                            .WithMany(c => c.CartModelDishModels)
                            .HasForeignKey(cd => cd.CartId),
                    cd =>
                        cd
                            .Property(cd => cd.Count)
                            .HasDefaultValue(1)
                );
        }
    }
}
