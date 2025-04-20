using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetBranchByIdQuery : IRequest<BranchDetails>
    {
        public required Guid Id { get; set; }
    }
}
