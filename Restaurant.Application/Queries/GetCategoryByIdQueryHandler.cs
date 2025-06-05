using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetCategoryByIdQueryHandler
        (IMapper mapper,
        IRestaurantDbContext dbContext)
        :
        IRequestHandler<GetCategoryByIdQuery, CategoryDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDetails> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Categories
                    .Include(e => e.Content)
                    .Include(e => e.Timestamps)
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);

            return _mapper.Map<CategoryDetails>(entity);
        }
    }
}
