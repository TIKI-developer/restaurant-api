using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderListQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetOrderListQuery, OrderList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderList> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var query =
                _dbContext
                .Orders
                .Include(e => e.Branch)
                .Include(e => e.Address)
                .Include(o => o.Items)
                .Include(e => e.User)
                .ThenInclude(e => e.Profile)
                .Include(e => e.Timestamps)
                .AsNoTracking()
                .ProjectTo<OrderItem>(_mapper.ConfigurationProvider)
                .AsQueryable();

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
