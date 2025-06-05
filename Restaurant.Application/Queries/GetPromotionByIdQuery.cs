using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetPromotionByIdQuery : IRequest<PromotionDetails>
    {
        public required Guid Id { get; set; }
    }
}
