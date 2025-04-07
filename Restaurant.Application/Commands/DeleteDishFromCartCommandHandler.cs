using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Commands
{
    public class DeleteDishFromCartCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<DeleteDishFromCartCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteDishFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await
                _dbContext.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Cart), request.UserId);

            var cartDish = cart.Items
                .FirstOrDefault(d => d.DishId == request.DishId)
                ?? throw new NotFoundException(nameof(Domain.Entities.Dish), request.DishId);

            if (cartDish.Count > 1)
            {
                cartDish.Count -= 1;
            }
            else
            {
                cart.Items.Remove(cartDish);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
