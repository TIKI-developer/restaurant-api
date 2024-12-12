using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Category.Queries.Get
{
    public class GetQuery : IRequest<CategoryList> { }
}
