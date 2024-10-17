using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.User.Commands.Register
{
    public class RegisterUserCommandHandler(IRestaurantDbContext dbContext, IPasswordHasher passwordHasher) : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userProfile = new ClientModel.ProfileModel
            {
                Name = request.Name
            };
            var user = new ClientModel
            {
                Id = Guid.NewGuid(),
                Profile = userProfile,
                Number = request.Number,
                PasswordHash = _passwordHasher.Generate(request.Password)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
