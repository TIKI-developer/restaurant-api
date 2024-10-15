using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Queries.GetCategory
{
    public class GetCategoryQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetCategoryQuery, CategoryDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDetailsViewModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Categories
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(CategoryModel), request.Id);
            }

            return _mapper.Map<CategoryDetailsViewModel>(entity);
        }
    }
}
