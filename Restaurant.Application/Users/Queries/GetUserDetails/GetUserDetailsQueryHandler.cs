using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, User>
    {
        public Task<User> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
