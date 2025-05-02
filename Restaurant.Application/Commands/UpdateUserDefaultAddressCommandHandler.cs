using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class UpdateUserDefaultAddressCommandHandler 
        (IRestaurantDbContext dbContext)
        : IRequestHandler<UpdateUserDefaultAddressCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateUserDefaultAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                .Users
                .FirstOrDefaultAsync(e => e.Id == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.UserId);

            var defaultAddress = await
                _dbContext
                .SavedAddresses
                .FirstOrDefaultAsync(e => e.Id == request.DefaultAddressId, cancellationToken)
                ?? throw new NotFoundException(nameof(SavedAddress), request.DefaultAddressId);

            user.DefaultAddressId = request.DefaultAddressId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
