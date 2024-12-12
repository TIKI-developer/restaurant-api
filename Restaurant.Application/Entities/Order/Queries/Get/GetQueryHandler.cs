using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.Get
{
    public class GetQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetQuery, OrderList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderList> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var threeDaysAgo = DateTime.UtcNow.AddDays(-3);

            var orders = await
                _dbContext
                    .Orders
                    .Include(o => o.Items)
                    .Include(e => e.Timestamps)
                    .Where(o => o.Timestamps.CreatedAt >= threeDaysAgo)
                    .OrderBy(o => o.Timestamps.CreatedAt)
                    .AsNoTracking()
                    .ProjectTo<OrderLookup>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new OrderList { Orders = orders };
        }
    }
}
