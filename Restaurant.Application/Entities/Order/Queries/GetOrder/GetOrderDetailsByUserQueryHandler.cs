using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Queries.GetOrder
{
    public class GetOrderDetailsByUserQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetOrderDetailsByUserQuery, OrderViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderViewModel> Handle(GetOrderDetailsByUserQuery request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                .Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Dish)
                .Include(o => o.User)
                .ThenInclude(u => u.Profile)
                .Where(o => o.User.Id == request.UserId)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException(nameof(OrderModel), request.Id);
            }
            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
