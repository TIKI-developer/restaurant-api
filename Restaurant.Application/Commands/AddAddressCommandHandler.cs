using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;


namespace Restaurant.Application.Commands
{
    public class AddAddressCommandHandler
        (IRestaurantDbContext dbContext)
        : IRequestHandler<AddAddressCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                .Users
                .FirstOrDefaultAsync(e => e.Id == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.UserId);

            var newAddress = new Address
            {
                Id = Guid.NewGuid(),
                Timestamps = new Timestamps
                { CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                City = request.City,
                Street = request.Street,
                BuildingNumber = request.BuildingNumber,
                ApartmentNumber = request.ApartmentNumber,
                Entrance = request.Entrance,
                Floor = request.Floor,
                UserId = user.Id,
                User = user,
            };

            await _dbContext.Addresses.AddAsync(newAddress, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newAddress.Id;
        }
    }
}
