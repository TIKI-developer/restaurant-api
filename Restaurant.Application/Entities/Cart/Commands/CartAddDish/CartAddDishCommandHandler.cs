using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Cart.Commands.CartAddDish
{
    public class CartAddDishCommandHandler : IRequestHandler<CartAddDishCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext;

        public CartAddDishCommandHandler(IRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CartAddDishCommand request, CancellationToken cancellationToken)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == request.ClientId, cancellationToken);

            if (cart == null)
            {
                throw new NotFoundException(nameof(CartModel), request.ClientId);
            }

            var dishCount = request.NewDishes
                .GroupBy(id => id)
                .ToDictionary(group => group.Key, group => group.Count());

            var existingDishIds = cart.Items
                .Select(d => d.DishId)
                .ToHashSet();

            foreach (var (dishId, count) in dishCount)
            {
                var existingCartDish = cart.Items.FirstOrDefault(d => d.DishId == dishId);
                
                if (existingCartDish != null)
                {
                    existingCartDish.Count += count;
                }
                else
                {
                    var dish = await _dbContext.Dishes.FindAsync(new object[] { dishId }, cancellationToken);
                    if (dish == null)
                    {
                        throw new NotFoundException(nameof(DishModel), dishId);
                    }

                    var cartDish = new CartItem
                    {
                        Dish = dish,
                        Count = count
                    };

                    cart.Items.Add(cartDish);
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
