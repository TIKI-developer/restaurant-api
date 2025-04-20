using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Queries
{
    public class GetBranchByIdQueryHandler 
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetBranchByIdQuery, BranchDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper; 

        public async Task<BranchDetails> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await
                _dbContext
                .Branches
                .Include(e => e.Address)
                .Include(e => e.Content)
                .Include(e => e.Schedule)
                .ThenInclude(e => e.Days)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Branch), cancellationToken);

            return _mapper.Map<BranchDetails>(branch);
        }
    }
}
