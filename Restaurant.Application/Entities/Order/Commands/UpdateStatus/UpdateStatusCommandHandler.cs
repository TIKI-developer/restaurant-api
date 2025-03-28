using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Order.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler
        (IRestaurantDbContext dbContext, 
        IMapper mapper,
        INotificationService notificationService) 
        : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        private readonly INotificationService _notificationService = notificationService;

        public async Task Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                    .Orders
                    .Include(e => e.User)
                    .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Order), request.Id);

            order.Status = request.NewStatus ?? order.Status;
            order.DeliveryCost = request.DeliveryCost ?? order.DeliveryCost;
            order.ReceiptAt = request.ReceiptAt ?? order.ReceiptAt;
            order.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (order.User.FncTokens.Count > 0)
            {
                foreach (var fncToken in order.User.FncTokens)
                {
                    _notificationService.Send(order.Status.ToString(), $"Статус заказа {order.Code}, обновлен", fncToken);
                }
            }
        }
    }
}
