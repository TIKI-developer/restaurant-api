using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.Cart;
using Restaurant.Domain.User.Client;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Cart.Commands.CartDeleteDish
{
    public class CartDeleteDishCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CartDeleteDishCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(CartDeleteDishCommand request, CancellationToken cancellationToken)
        {
            var cart = await
                _dbContext
                    .Carts
                    .Include(u => u.Dishes)
                    .FirstOrDefaultAsync(d => d.ClientId == request.UserId, cancellationToken);

            if (cart == null)
            {
                throw new NotFoundException(nameof(CartModel), request.UserId);
            }

            var dish = await
                _dbContext
                    .Dishes
                    .FirstOrDefaultAsync(d => d.Id == request.DishId, cancellationToken);

            if (dish == null) 
            {
                throw new NotFoundException(nameof(DishModel), request.DishId);
            }

            cart.Dishes.Remove(dish);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
