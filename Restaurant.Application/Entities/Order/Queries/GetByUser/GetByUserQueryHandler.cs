using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.GetByUser
{
    public class GetByUserQueryHandler
        (IMapper mapper,
        IRestaurantDbContext dbContext)
        :
        IRequestHandler<GetByUserQuery, OrderList>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<OrderList> Handle(GetByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.User), request.UserId);

            var orders = await
                _dbContext
                .Orders
                .Include(e => e.Timestamps)
                .OrderByDescending(e => e.Timestamps.CreatedAt)
                .Where(e => e.User.Id == request.UserId)
                .AsNoTracking()
                .ProjectTo<OrderLookup>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderList { Orders = orders };
        }
    }
}