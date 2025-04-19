using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;


namespace Restaurant.Application.Commands
{
    public class AddSavedAddressCommandHandler
        (IRestaurantDbContext dbContext)
        : IRequestHandler<AddSavedAddressCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(AddSavedAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                .Users
                .FirstOrDefaultAsync(e => e.Id == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.UserId);

            var newAddress = new SavedAddress
            {
                Id = Guid.NewGuid(),
                Timestamps = new Timestamps
                { CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                Name = request.Name,
                Address = request.Address,
                UserId = user.Id,
                User = user,
            };

            await _dbContext.SavedAddresses.AddAsync(newAddress, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newAddress.Id;
        }
    }
}
