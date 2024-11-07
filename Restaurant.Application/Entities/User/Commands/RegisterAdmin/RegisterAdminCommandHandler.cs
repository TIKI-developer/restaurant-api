using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User.Admin;


namespace Restaurant.Application.Entities.User.Commands.RegisterAdmin
{
    public class RegisterAdminCommandHandler(
        IRestaurantDbContext dbContext, 
        IPasswordHasher passwordHasher, 
        IJwtProvider jwtProvider) 
        : IRequestHandler<RegisterAdminCommand, string>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new AdminModel
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                PasswordHash = _passwordHasher.Generate(request.Password)
            };

            await _dbContext.Users.AddAsync(admin, cancellationToken);
            var token = _jwtProvider.Generate(admin);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return token;
        }
    }
}
