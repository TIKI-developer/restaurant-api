using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;


namespace Restaurant.Application.Dishes.Queries.GetDishDetails
{
    public class GetDishDetailsQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetDishDetailsQuery, DishDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishDetailsViewModel> Handle(GetDishDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Dishes
                .FirstOrDefaultAsync(dish => 
                dish.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Dish), request.Id);
            }

            return _mapper.Map<DishDetailsViewModel>(entity);
        }
    }
}
