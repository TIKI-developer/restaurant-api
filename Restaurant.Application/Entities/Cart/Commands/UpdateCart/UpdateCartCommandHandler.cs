using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.Cart;

namespace Restaurant.Application.Entities.Cart.Commands.UpdateCart
{
    public class UpdateCartCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<UpdateCartCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Carts
                    .FirstOrDefaultAsync(e => e.ClientId == request.ClientId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserCartModel), request.ClientId);
            }

            var dishEntities = await
                _dbContext
                    .Dishes
                    .Where(d => request.Dishes.Contains(d.Id))
                    .ToListAsync(cancellationToken);


            entity.Dishes = dishEntities;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
