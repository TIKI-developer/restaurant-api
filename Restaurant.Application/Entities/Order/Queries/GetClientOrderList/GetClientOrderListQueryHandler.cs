using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Order.Queries.GetClientOrderList
{
    public class GetClientOrderListQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetClientOrderListQuery, OrderListViewModel>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<OrderListViewModel> Handle(GetClientOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await
                _dbContext
                .Orders
                .Where(order => order.Client.Id == request.ClientId)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListViewModel { Orders = ordersQuery };
        }
    }
}
