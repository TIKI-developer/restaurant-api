using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands.Update
{
    public class UpdateCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Users
                .Include(e => e.Profile)
                .ThenInclude(e => e.Address)
                .Include(e => e.Timestamps)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.User), request.Id);

            entity.Profile.Name = request.Name ?? entity.Profile.Name;
            entity.Profile.Address = request.Address ?? entity.Profile.Address;
            entity.PhoneNumber = request.Number ?? entity.PhoneNumber;
            entity.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
