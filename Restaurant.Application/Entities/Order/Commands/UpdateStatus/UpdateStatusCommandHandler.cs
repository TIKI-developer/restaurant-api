using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Order.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                    .Orders
                    .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Order), request.Id);

            order.Status = request.NewStatus ?? order.Status;
            order.DeliveryCost = request.DeliveryCost ?? order.DeliveryCost;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
