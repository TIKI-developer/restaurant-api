using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPublished
{
    public class GetPublishedQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetPublishedQuery, PromotionList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionList> Handle(GetPublishedQuery request, CancellationToken cancellationToken)
        {
            var promotions = await
                _dbContext
                .Promotions
                .Include(p => p.Content)
                .Where(p => p.Content.IsPublished == true)
                .ProjectTo<PromotionLookup>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PromotionList { Promotions = promotions };
        }
    }
}
