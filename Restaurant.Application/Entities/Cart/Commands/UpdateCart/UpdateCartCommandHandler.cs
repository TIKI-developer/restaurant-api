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
            var client = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(e => e.Id == request.ClientId, cancellationToken) as ClientModel;

            if (client == null)
            {
                throw new NotFoundException(nameof(UserModel), request.ClientId);
            }

            var dishes = await
                _dbContext
                    .Dishes
                    .Where(d => request.Dishes.Contains(d.Id))
                    .ToListAsync(cancellationToken);


            //client.Cart.Items = dishes;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
