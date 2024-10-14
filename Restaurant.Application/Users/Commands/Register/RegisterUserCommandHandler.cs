using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Users.Commands.CreateUser
{
    public class RegisterUserCommandHandler(IRestaurantDbContext dbContext, IPasswordHasher passwordHasher) : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Number = request.Number,
                PasswordHash = _passwordHasher.Generate(request.Password)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
