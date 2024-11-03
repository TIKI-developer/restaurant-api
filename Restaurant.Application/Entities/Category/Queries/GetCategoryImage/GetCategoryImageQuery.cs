using MediatR;

namespace Restaurant.Application.Entities.Category.Queries.GetCategoryImage
{
    public class GetCategoryImageQuery : IRequest<CategoryImageViewModel>
    {
        public Guid Id { get; set; }
    }
}
