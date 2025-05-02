using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetCartByUserQueryHandler
        (IMapper mapper,
        IRestaurantDbContext dbContext)
        :
        IRequestHandler<GetCartByUserQuery, CartDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CartDetails> Handle(GetCartByUserQuery request, CancellationToken cancellationToken)
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
