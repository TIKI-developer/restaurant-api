using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;

namespace Restaurant.Application.Entities.Cart.Commands.CartAddDish
{
    public class CartAddDishCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CartAddDishCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(CartAddDishCommand request, CancellationToken cancellationToken)
        {
            var cart = await
                _dbContext
                    .Carts
                    .Include(c => c.Dishes)
                    .Include(c => c.CartModelDishModels)
                    .FirstOrDefaultAsync(c => c.ClientId == request.ClientId, cancellationToken);

            if (cart == null)
            {
                throw new NotFoundException(nameof(CartModel), request.ClientId);
            }
            else
            {
                var dishCount = request.NewDishes
                        .GroupBy(id => id)
                        .ToDictionary(group => group.Key, group => group.Count());
                var newDishes = await
                    _dbContext
                        .Dishes
                        .Where(c => request.NewDishes.Contains(c.Id))
                        .ToListAsync(cancellationToken);

                foreach (var dish in newDishes)
                {
                    var count = dishCount[dish.Id];

                    var cartDish = new CartModelDishModel
                    {
                        Dish = dish,
                        Count = count
                    };

                    cart.CartModelDishModels.Add(cartDish);
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
