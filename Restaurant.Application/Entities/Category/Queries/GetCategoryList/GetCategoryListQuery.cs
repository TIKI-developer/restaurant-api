using MediatR;

namespace Restaurant.Application.Entities.Category.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<CategoryListViewModel> { }
}
