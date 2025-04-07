using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.User.Queries.GetById
{
    public class GetByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetByIdQuery, UserDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                .Users
                .Include(e => e.Profile)
                .FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.User), request.Id);

            return _mapper.Map<UserDetails>(user);
        }
    }
}
