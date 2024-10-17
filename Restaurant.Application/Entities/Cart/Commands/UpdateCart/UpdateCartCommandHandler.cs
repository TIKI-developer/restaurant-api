using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.User;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.Cart.Commands.UpdateCart
{
    public class UpdateCartCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<UpdateCartCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var entityClient = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(e => e.Id == request.ClientId, cancellationToken) as ClientModel;

            if (entityClient == null)
            {
                throw new NotFoundException(nameof(UserModel), request.ClientId);
            }

            var dishEntities = await
                _dbContext
                    .Dishes
                    .Where(d => request.Dishes.Contains(d.Id))
                    .ToListAsync(cancellationToken);


            entityClient.Cart.Dishes = dishEntities;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
