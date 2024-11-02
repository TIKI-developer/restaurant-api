using MediatR;

namespace Restaurant.Application.Entities.Category.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
