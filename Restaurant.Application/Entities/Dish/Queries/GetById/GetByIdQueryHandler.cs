using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetById
{
    public class GetByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetByIdQuery, DishDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Dishes
                .Include<Domain.Dish, List<Domain.Category>>(d => d.Categories)
                .FirstOrDefaultAsync(dish =>
                dish.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Dish), request.Id);

            return _mapper.Map<DishDetails>(entity);
        }
    }
}
