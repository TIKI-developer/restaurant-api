using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommandHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                    .Orders
                    .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(OrderModel), request.Id);

            order.Status = request.NewStatus;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
