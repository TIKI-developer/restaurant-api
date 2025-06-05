using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetSavedAddressListByUserQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetSavedAddressListByUserQuery, SavedAddressList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<SavedAddressList> Handle(GetSavedAddressListByUserQuery request, CancellationToken cancellationToken)
        {
            var addresses = await
                _dbContext
                .SavedAddresses
                .Where(e => e.User.Id == request.UserId)
                .ProjectTo<SavedAddressDetails>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new SavedAddressList { SavedAddresses = addresses };
        }
    }
}
