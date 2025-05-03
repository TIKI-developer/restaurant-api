using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class UpdateOrderStatusCommandHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper,
        INotificationService notificationService)
        : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        private readonly INotificationService _notificationService = notificationService;

        public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                    .Orders
                    .Include(e => e.User)
                    .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Entities.Order), request.Id);

            order.Status = request.NewStatus ?? order.Status;
            order.DeliveryCost = request.DeliveryCost ?? order.DeliveryCost;
            order.ReceiptAt = request.ReceiptAt ?? order.ReceiptAt;
            order.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (order.User.FncTokens.Count > 0)
            {
                var messageBody = order.Status switch
                {
                    OrderStatus.Pending => "Скоро возьмем ваш заказ в работу",
                    OrderStatus.Adopted => "Заказ принят, ожидайте звонка оператора",
                    OrderStatus.Working => "Начали готовить ваш заказ",
                    OrderStatus.Delivering => "Заказ передан в доставку",
                    OrderStatus.Completed => "Ваш заказ завершен",
                    OrderStatus.Rejected => "Заказ был отменен отменён",
                    _ => "Неизвестный статус"
                };

                foreach (var fncToken in order.User.FncTokens)
                {
                    await _notificationService.Send($"Статус заказа {order.Code}, обновлен", messageBody, fncToken.Value);
                }
            }
        }
    }
}
