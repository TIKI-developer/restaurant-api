using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Address.Queries.GetById
{
    public class GetByIdQueryHandler 
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetByIdQuery, AddressDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<AddressDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await
                _dbContext
                .Addresses
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Address), request.Id);

            return _mapper.Map<AddressDetails>(address);
        }
    }
}
