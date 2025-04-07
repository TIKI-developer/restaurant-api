using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetAddressByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetAddressByIdQuery, AddressDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<AddressDetails> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await
                _dbContext
                .Addresses
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Address), request.Id);

            return _mapper.Map<AddressDetails>(address);
        }
    }
}
