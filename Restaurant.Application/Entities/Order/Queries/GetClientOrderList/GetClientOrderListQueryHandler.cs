using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.Order.Queries.GetClientOrderList
{
    public class GetClientOrderListQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetClientOrderListQuery, OrderListViewModel>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<OrderListViewModel> Handle(GetClientOrderListQuery request, CancellationToken cancellationToken)
        {
            var client = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.ClientId, cancellationToken);

            if (client == null)
            {
                throw new NotFoundException(nameof(ClientModel), request.ClientId);
            }
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
