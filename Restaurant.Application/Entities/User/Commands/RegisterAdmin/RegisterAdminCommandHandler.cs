using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User.Admin;


namespace Restaurant.Application.Entities.User.Commands.RegisterAdmin
{
    public class RegisterAdminCommandHandler(IRestaurantDbContext dbContext, IPasswordHasher passwordHasher) : IRequestHandler<RegisterAdminCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<Guid> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new AdminModel
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                PasswordHash = _passwordHasher.Generate(request.Password)
            };

            await _dbContext.Users.AddAsync(admin);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return admin.Id;
        }
    }
}
