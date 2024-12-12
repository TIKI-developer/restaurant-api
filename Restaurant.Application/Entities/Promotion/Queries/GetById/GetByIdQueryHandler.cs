using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.GetById
{
    public class GetByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetByIdQuery, PromotionDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var promotion = await
                _dbContext
                .Promotions
                .Include(e => e.Content)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Promotion), request.Id);

            return _mapper.Map<PromotionDetails>(promotion);
        }
    }
}
