using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetAdvancedPromotionListQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetAdvancedPromotionListQuery, PromotionList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionList> Handle(GetAdvancedPromotionListQuery request, CancellationToken cancellationToken)
        {
            var promotions = await
                _dbContext
                .Promotions
                .Include(p => p.Content)
                .Where(p => p.Content.IsPublished == true && p.IsAdvanced == true)
                .ProjectTo<PromotionItem>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new PromotionList { Promotions = promotions };
        }
    }
}
