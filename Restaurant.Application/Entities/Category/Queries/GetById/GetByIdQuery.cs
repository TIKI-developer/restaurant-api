using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Category.Queries.GetById
{
    public class GetByIdQuery : IRequest<CategoryDetails>
    {
        public required Guid Id { get; set; }
    }
}
