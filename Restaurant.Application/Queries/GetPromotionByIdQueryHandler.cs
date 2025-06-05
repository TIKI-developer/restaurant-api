using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetPromotionByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetPromotionByIdQuery, PromotionDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionDetails> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var promotion = await
                _dbContext
                .Promotions
                .Include(e => e.Content)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Promotion), request.Id);

            return _mapper.Map<PromotionDetails>(promotion);
        }
    }
}
