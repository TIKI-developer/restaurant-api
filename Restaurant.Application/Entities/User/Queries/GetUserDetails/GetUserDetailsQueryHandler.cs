using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.User.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserDetailsQuery, ClientDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ClientDetailsViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Users
                .FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserModel), request.Id);
            }

            return _mapper.Map<ClientDetailsViewModel>(entity);
        }
    }
}
