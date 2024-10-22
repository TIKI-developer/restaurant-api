using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Dish;
using Restaurant.Domain.Order;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var client = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.ClientId, cancellationToken);
            var cart = await
                _dbContext
                    .Carts
                    .Include(c => c.Dishes)
                    .FirstOrDefaultAsync(c => c.ClientId == request.ClientId, cancellationToken);

            if (cart.Dishes == null)
            {
                throw new Exception("Cart is clear");
            }    
            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                Dishes = new List<DishModel>(cart.Dishes),
                Status = OrderStatus.Pending,
                CreationDateTime = DateTime.UtcNow,
                Client = client as ClientModel
            };

            await _dbContext.Orders.AddAsync(order);
            cart.Dishes.Clear();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
