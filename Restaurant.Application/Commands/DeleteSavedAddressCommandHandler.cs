using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Commands
{
    public class DeleteSavedAddressCommandHandler
        (IRestaurantDbContext dbContext)
        : IRequestHandler<DeleteSavedAddressCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteSavedAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await
                _dbContext
                .SavedAddresses
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.SavedAddress), request.Id);

            _dbContext.SavedAddresses.Remove(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
