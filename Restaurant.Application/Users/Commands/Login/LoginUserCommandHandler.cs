using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Users.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRestaurantDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public LoginUserCommandHandler(IRestaurantDbContext restaurantDbContext, 
                                       IPasswordHasher passwordHasher,
                                       IJwtProvider jwtProvider)
        {
            _dbContext = restaurantDbContext;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user =
                await _dbContext
                        .Users
                        .FirstOrDefaultAsync(user => user.Number == request.Number, cancellationToken);
            if (user == null) {
                throw new Exception("User not found");
            }

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash)) {
                throw new Exception("Incorrect password");
            }
            var token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
