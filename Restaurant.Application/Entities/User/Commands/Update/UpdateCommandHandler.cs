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
            var user = await
                _dbContext
                .Users
                .Include(e => e.Profile)
                .Include(e => e.Timestamps)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.User), request.Id);

            user.Profile.Name = request.Name ?? user.Profile.Name;
            user.DefaultAddressId = request.DefaultAddressId ?? user.DefaultAddressId;
            user.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
