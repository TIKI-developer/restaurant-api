using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Category.Queries.Get
{
    public class GetPublishedQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetPublishedQuery, CategoryList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryList> Handle(GetPublishedQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await
                _dbContext
                    .Categories
                    .Include(e => e.Content)
                    .Where(e => e.Content.IsPublished == true)
                    .ProjectTo<CategoryLookup>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new CategoryList { Categories = categoriesQuery };
        }
    }
}
