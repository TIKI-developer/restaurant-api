using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands.Login
{
    public class LoginUserCommandHandler(IRestaurantDbContext restaurantDbContext,
                                         IPasswordHasher passwordHasher,
                                         IJwtProvider jwtProvider)
                                         :
                                         IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRestaurantDbContext _dbContext = restaurantDbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(user => user.Number == request.Number, cancellationToken);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Incorrect password");
            }
            var token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
