using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Commands
{
    public class RemoveAddressCommandHandler
        (IRestaurantDbContext dbContext)
        : IRequestHandler<RemoveAddressCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await
                _dbContext
                .Addresses
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Address), request.Id);

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
