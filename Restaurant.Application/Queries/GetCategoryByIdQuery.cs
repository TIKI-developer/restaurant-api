using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDetails>
    {
        public required Guid Id { get; set; }
    }
}
