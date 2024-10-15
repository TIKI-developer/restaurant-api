using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.User;


namespace Restaurant.Application.Entities.User.Commands.EditProfile
{
    public class EditProfileCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<EditProfileCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = await 
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserModel), request.Id);
            }

            entity.Name = request.Name ?? entity.Name;
            entity.Number = request.Number ?? entity.Number;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
