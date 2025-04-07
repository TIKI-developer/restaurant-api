using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Address.Queries.GetByUser
{
    public class GetAddressListByUserQueryHandler 
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetAddressListByUserQuery, AddressList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<AddressList> Handle(GetAddressListByUserQuery request, CancellationToken cancellationToken)
        {
            var addresses = await
                _dbContext
                .Addresses
                .Where(e => e.User.Id == request.UserId)
                .ProjectTo<AddressDetails>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AddressList { Addresses = addresses };
        }
    }
}
