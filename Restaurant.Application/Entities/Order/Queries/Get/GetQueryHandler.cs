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
            var query = _dbContext.Orders
                .Include(o => o.Items)
                .Include(e => e.User)
                .ThenInclude(e => e.Profile)
                .Include(e => e.Timestamps)
                .AsNoTracking()
                .ProjectTo<OrderLookup>(_mapper.ConfigurationProvider);

            if (request.ByLastDays.HasValue)
            {
                var filterDate = DateTime.UtcNow.AddDays(-request.ByLastDays.Value);
                query = query.Where(o => o.Timestamps.CreatedAt >= filterDate);
            }

            var orders = await query
                .OrderBy(o => o.Timestamps.CreatedAt)
                .ToListAsync(cancellationToken);

            return new OrderList { Orders = orders };
        }
    }
}
