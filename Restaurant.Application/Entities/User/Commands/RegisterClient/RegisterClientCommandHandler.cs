using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.User.Commands.RegisterClient
{
    public class RegisterClientCommandHandler(
        IRestaurantDbContext dbContext, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider) 
        : IRequestHandler<RegisterClientCommand, string>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var userProfile = new ClientModel.ProfileModel
            {
                Name = request.Name
            };
            var client = new ClientModel
            {
                Id = Guid.NewGuid(),
                Profile = userProfile,
                Number = request.Number,
                PasswordHash = _passwordHasher.Generate(request.Password)
            };

            await _dbContext.Users.AddAsync(client, cancellationToken);

            var cart = new CartModel
            {
                ClientId = client.Id,
                Items = [],
                Client = client
            };

            await _dbContext.Carts.AddAsync(cart, cancellationToken);
            var token = _jwtProvider.Generate(client);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return token;
        }
    }
}
