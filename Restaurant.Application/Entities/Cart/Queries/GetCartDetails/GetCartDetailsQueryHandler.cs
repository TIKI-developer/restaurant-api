using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class GetCartDetailsQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetCartDetailsQuery, CartDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CartDetailsViewModel> Handle(GetCartDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Carts
                    .FirstOrDefaultAsync(e => e.ClientId == request.ClientId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserModel), request.ClientId);
            }
            Console.WriteLine(entity.Dishes.Count);
            return _mapper.Map<CartDetailsViewModel>(entity);
        }
    }
}
