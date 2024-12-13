using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.GetAdvanced
{
    public class GetAdvancedQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetAdvancedQuery, PromotionList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionList> Handle(GetAdvancedQuery request, CancellationToken cancellationToken)
        {
            var promotions = await
                _dbContext
                .Promotions
                .Include(p => p.Content)
                .Where(p => p.Content.IsPublished == true && p.IsAdvanced == true)
                .ProjectTo<PromotionLookup>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new PromotionList { Promotions = promotions };
        }
    }
}
