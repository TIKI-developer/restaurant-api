using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Entities.Dish.Queries.GetDishImageQuery;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishImage
{
    public class GetDishImagesQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) 
        : IRequestHandler<GetDishImageQuery.GetDishImageQuery, DishImagesViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishImagesViewModel> Handle(GetDishImageQuery.GetDishImageQuery request, CancellationToken cancellationToken)
        {
            var dish = await
                _dbContext
                    .Dishes
                    .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (dish == null)
            {
                throw new NotFoundException(nameof(DishModel), request.Id);
            }

            return new DishImagesViewModel { Image = dish.Name };
        }
    }
}
