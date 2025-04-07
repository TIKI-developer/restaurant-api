using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Cart.Queries.GetDetails
{
    public class GetByUserQueryHandler
        (IMapper mapper,
        IRestaurantDbContext dbContext)
        :
        IRequestHandler<GetByUserQuery, CartDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CartDetails> Handle(GetByUserQuery request, CancellationToken cancellationToken)
        {
            var cart = await
                _dbContext
                    .Carts
                    .Include(c => c.Items)
                    .ThenInclude(i => i.Dish)
                    .FirstOrDefaultAsync(e => e.UserId == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Entities.Cart), request.UserId);

            return _mapper.Map<CartDetails>(cart);
        }
    }
}
