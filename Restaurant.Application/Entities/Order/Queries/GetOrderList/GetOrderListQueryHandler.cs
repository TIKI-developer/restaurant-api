using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class GetOrderListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetOrderListQuery, OrderListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderListViewModel> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await
                _dbContext
                    .Orders
                    .Include(o => o.Dishes)
                    .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new OrderListViewModel { Orders = orders };
        }
    }
}
