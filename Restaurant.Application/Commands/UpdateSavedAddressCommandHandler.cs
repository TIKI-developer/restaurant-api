using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Commands
{
    public class UpdateSavedAddressCommandHandler
        (IRestaurantDbContext dbContext)
        : IRequestHandler<UpdateSavedAddressCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateSavedAddressCommand request, CancellationToken cancellationToken)
        {
            var savedAddress = await
                _dbContext
                .SavedAddresses
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.SavedAddress), request.Id);

            savedAddress.Name = request.Name;
            savedAddress.Address = request.Address;
            savedAddress.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
