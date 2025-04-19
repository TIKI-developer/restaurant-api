using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetSavedAddressByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetSavedAddressByIdQuery, SavedAddressDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<SavedAddressDetails> Handle(GetSavedAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await
                _dbContext
                .SavedAddresses
                .Include(e => e.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.SavedAddress), request.Id);

            return _mapper.Map<SavedAddressDetails>(address);
        }
    }
}
