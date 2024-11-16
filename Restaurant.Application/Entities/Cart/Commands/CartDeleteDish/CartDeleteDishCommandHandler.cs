using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Cart.Commands.CartDeleteDish
{
    public class CartDeleteDishCommandHandler : IRequestHandler<CartDeleteDishCommand>
    {
        private readonly IRestaurantDbContext _dbContext;

        public CartDeleteDishCommandHandler(IRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CartDeleteDishCommand request, CancellationToken cancellationToken)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartModelDishModels)
                .FirstOrDefaultAsync(c => c.ClientId == request.UserId, cancellationToken);

            if (cart == null)
            {
                throw new NotFoundException(nameof(CartModel), request.UserId);
            }

            var cartDish = cart.CartModelDishModels
                .FirstOrDefault(d => d.DishId == request.DishId);

            if (cartDish == null)
            {
                throw new NotFoundException(nameof(DishModel), request.DishId);
            }

            if (cartDish.Count > 1)
            {
                cartDish.Count -= 1;
            }
            else
            {
                cart.CartModelDishModels.Remove(cartDish);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
