using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.User.Commands.RegisterClient
{
    public class RegisterClientCommandHandler(IRestaurantDbContext dbContext, IPasswordHasher passwordHasher) : IRequestHandler<RegisterClientCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<Guid> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
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

            await _dbContext.Users.AddAsync(client);

            var cart = new CartModel
            {
                ClientId = client.Id,
                Dishes = [],
                Client = client
            };

            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
