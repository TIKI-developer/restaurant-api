using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class GetCartDetailsQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetCartDetailsQuery, CartDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CartDetailsViewModel> Handle(GetCartDetailsQuery request, CancellationToken cancellationToken)
        {
            var entityClient = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(e => e.Id == request.ClientId, cancellationToken) as ClientModel;

            if (entityClient == null)
            {
                throw new NotFoundException(nameof(UserModel), request.ClientId);
            }
            Console.WriteLine(entityClient.Cart.Dishes.Count);
            return _mapper.Map<CartDetailsViewModel>(entityClient);
        }
    }
}
