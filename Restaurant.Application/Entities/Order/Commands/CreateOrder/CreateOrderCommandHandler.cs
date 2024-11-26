using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
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
            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            var cart = await
                _dbContext
                    .Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken);

            if (cart.Items == null || cart.Items.Count <= 0)
            {
                throw new Exception("Cart is clear");
            }    
            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                Items = cart.Items.Select(ci => new OrderItem
                {
                    DishId = ci.DishId,
                    Count = ci.Count
                }).ToList(),
                PersonQuantity = request.PersonQuantity,
                Status = OrderStatus.Pending,
                Address = request.Address,
                CreationDateTime = DateTime.UtcNow,
                AddChopsticks = request.AddChopsticks,
                AddForks = request.AddForks,
                User = user
            };

            await _dbContext.Orders.AddAsync(order);
            cart.Items.Clear();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
