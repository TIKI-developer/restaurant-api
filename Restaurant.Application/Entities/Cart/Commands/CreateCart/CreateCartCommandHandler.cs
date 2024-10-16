using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;

namespace Restaurant.Application.Entities.Cart.Commands.CreateCart
{
    public class CreateCartCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CreateCartCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserCartModel
            {
                ClientId = request.ClientId,
            };

            await _dbContext.Carts.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
