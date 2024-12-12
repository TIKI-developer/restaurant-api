using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.GetById
{
    public class GetByIdQuery : IRequest<PromotionDetails>
    {
        public required Guid Id { get; set; }
    }
}
