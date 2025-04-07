using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Commands
{
    public class DeleteAddressCommandHandler
        (IRestaurantDbContext dbContext)
        : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
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
