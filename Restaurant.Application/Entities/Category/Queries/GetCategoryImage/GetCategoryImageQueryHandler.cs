using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Queries.GetCategoryImage
{
    public class GetCategoryImageQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) 
        : IRequestHandler<GetCategoryImageQuery, CategoryImageViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryImageViewModel> Handle(GetCategoryImageQuery request, CancellationToken cancellationToken)
        {
            var category = await
                _dbContext
                    .Categories
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (category == null)
            {
                throw new NotFoundException(nameof(CategoryModel), request.Id);
            }

            return new CategoryImageViewModel { Image = category.Image };
        }
    }
}
