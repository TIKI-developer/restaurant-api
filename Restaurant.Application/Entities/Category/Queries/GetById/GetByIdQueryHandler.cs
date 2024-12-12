using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Category.Queries.GetById
{
    public class GetByIdQueryHandler
        (IMapper mapper,
        IRestaurantDbContext dbContext)
        :
        IRequestHandler<GetByIdQuery, CategoryDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Categories
                    .Include(e => e.Content)
                    .Include(e => e.Timestamps)
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Category), request.Id);

            return _mapper.Map<CategoryDetails>(entity);
        }
    }
}
