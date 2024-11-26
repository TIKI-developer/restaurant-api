using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class GetUserOrderListQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetUserOrderListQuery, OrderListViewModel>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<OrderListViewModel> Handle(GetUserOrderListQuery request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(UserModel), request.UserId);
            }
            var ordersQuery = await
                _dbContext
                .Orders
                .Where(order => order.User.Id == request.UserId)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListViewModel { Orders = ordersQuery };
        }
    }
}
