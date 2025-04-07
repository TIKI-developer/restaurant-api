using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderByUserQueryHandler
        (IMapper mapper,
        IRestaurantDbContext dbContext)
        :
        IRequestHandler<GetOrderByUserQuery, OrderList>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<OrderList> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Entities.User), request.UserId);

            var orders = await
                _dbContext
                .Orders
                .Include(e => e.Timestamps)
                .OrderByDescending(e => e.Timestamps.CreatedAt)
                .Where(e => e.User.Id == request.UserId)
                .AsNoTracking()
                .ProjectTo<OrderItem>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderList { Orders = orders };
        }
    }
}