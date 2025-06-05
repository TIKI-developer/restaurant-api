using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetDishByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetDishByIdQuery, DishDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishDetails> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Dishes
                .Include(d => d.Categories)
                .FirstOrDefaultAsync(dish =>
                dish.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Dish), request.Id);

            return _mapper.Map<DishDetails>(entity);
        }
    }
}
