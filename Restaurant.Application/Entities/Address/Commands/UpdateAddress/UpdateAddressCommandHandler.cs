using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler 
        (IRestaurantDbContext dbContext)
        : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await
                _dbContext
                .Addresses
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Address), request.Id);

            address.City = request.City ?? address.City;
            address.Street = request.Street ?? address.Street;
            address.BuildingNumber = request.BuildingNumber ?? address.BuildingNumber;
            address.ApartmentNumber = request.ApartmentNumber ?? address.ApartmentNumber;
            address.Entrance = request.Entrance ?? address.Entrance;
            address.Floor = request.Floor ?? address.Floor;
            address.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
