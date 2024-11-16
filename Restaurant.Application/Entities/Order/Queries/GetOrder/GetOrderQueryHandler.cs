using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Queries.GetOrder
{
    public class GetOrderQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                .Orders
                .Include(o => o.Dishes)
                .Include(o => o.Client)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException(nameof(OrderModel), request.Id);
            }
            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
