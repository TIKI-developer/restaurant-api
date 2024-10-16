using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
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

            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                Dishes = request.Dishes,
                CreationDateTime = DateTime.UtcNow,
                Client = client as ClientModel
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
