using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    internal class GetBranchListQueryHandler 
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetBranchListQuery, BranchList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<BranchList> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
        {
            var branches = await
                _dbContext
                .Branches
                .Include(e => e.Address)
                .Include(e => e.Content)
                .Include(e => e.Schedule)
                .ThenInclude(e => e.Days)
                .AsNoTracking()
                .ProjectTo<BranchItem>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BranchList { Branches = branches };
        }
    }
}
