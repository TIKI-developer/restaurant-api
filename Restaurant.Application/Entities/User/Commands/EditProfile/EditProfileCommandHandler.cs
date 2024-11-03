using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.User;
using Restaurant.Domain.User.Client;


namespace Restaurant.Application.Entities.User.Commands.EditProfile
{
    public class EditProfileCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<EditProfileCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = await 
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) as ClientModel;

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserModel), request.Id);
            }

            entity.Profile.Name = request.Name ?? entity.Profile.Name;
            entity.Profile.Address = request.Address ?? entity.Profile.Address;
            entity.Number = request.Number ?? entity.Number;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
