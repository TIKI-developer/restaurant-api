using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class AddDishToCartCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<AddDishToCartCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(AddDishToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await
                _dbContext
                .Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Cart), request.UserId);

            var dishId = request.DishId;

            var existingCartDish =
                cart
                .Items
                .FirstOrDefault(d => d.DishId == dishId);

            if (existingCartDish != null)
            {
                existingCartDish.Count += 1;
            }
            else
            {
                var dish = await
                    _dbContext
                    .Dishes
                    .FindAsync([dishId], cancellationToken)
                    ?? throw new NotFoundException(nameof(Dish), dishId);

                var cartDish = new CartDishItem
                {
                    DishId = dishId,
                    Dish = dish,
                    Cart = cart,
                    CartId = cart.UserId,
                    Count = 1
                };

                cart.Items.Add(cartDish);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
