using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    internal class GetPublishedBranchListQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper) 
        : IRequestHandler<GetPublishedBranchListQuery, BranchList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<BranchList> Handle(GetPublishedBranchListQuery request, CancellationToken cancellationToken)
        {
            var branches = await
                _dbContext
                .Branches
                .Include(e => e.Address)
                .Include(e => e.Content)
                .Include(e => e.Schedule)
                .ThenInclude(e => e.Days)
                .AsNoTracking()
                .Where(e => e.Content.IsPublished == true)
                .ProjectTo<BranchItem>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BranchList { Branches = branches };
        }
    }
}
