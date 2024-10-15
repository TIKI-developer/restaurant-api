using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Domain.User;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var clientEntity = await
                _dbContext
                .Users
                .FirstOrDefaultAsync(e => e.Id == request.ClientId, cancellationToken);

            if (clientEntity == null)
            {
                throw new NotFoundException(nameof(UserModel), request.ClientId);
            }
            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                Dishes = request.Dishes,
                CreationDateTime = DateTime.UtcNow,
                Client = (ClientModel)clientEntity
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
