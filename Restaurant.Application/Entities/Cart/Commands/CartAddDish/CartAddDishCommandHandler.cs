using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Cart.Commands.CartAddDish
{
    public class CartAddDishCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CartAddDishCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(CartAddDishCommand request, CancellationToken cancellationToken)
        {
            var cart = await 
                _dbContext
                .Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(CartModel), request.UserId);

            var dishId = request.NewDish;

            var existingCartDish = 
                cart
                .Items
                .FirstOrDefault(d => d.DishId == dishId);

            if (existingCartDish != null) {
                existingCartDish.Count += 1;
            }
            else
            {
                var dish = await
                    _dbContext
                    .Dishes
                    .FindAsync([dishId], cancellationToken)
                    ?? throw new NotFoundException(nameof(DishModel), dishId);

                var cartDish = new CartItem
                {
                    DishId= dishId,
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
