using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;


namespace Restaurant.Application.Commands
{
    public class LoginCommandHandler
        (IRestaurantDbContext restaurantDbContext,
        IAdminIdentityProvider adminIdentityProvider,
        IJwtProvider jwtProvider)
        :
        IRequestHandler<LoginCommand, string>
    {
        private readonly IRestaurantDbContext _dbContext = restaurantDbContext;
        private readonly IAdminIdentityProvider _adminIdentityProvider = adminIdentityProvider;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var verification = await
                _dbContext
                .Verifications
                .FirstOrDefaultAsync(v => v.Number == request.PhoneNumber, cancellationToken);

            if (verification == null || string.IsNullOrEmpty(verification.CheckId) || !verification.CanLogin)
            {
                throw new Exception("Верификация не пройдена!");
            }

            var user = await
                _dbContext
                .Users
                .FirstOrDefaultAsync(user => user.PhoneNumber == request.PhoneNumber, cancellationToken);

            string token;

            if (user == null)
            {
                var userProfile = new UserProfile
                {
                    Name = request.Name
                };
                User newUser;

                if (_adminIdentityProvider.IsAdmin(request))
                {
                    newUser = new Admin
                    {
                        Id = Guid.NewGuid(),
                        Profile = userProfile,
                        PhoneNumber = request.PhoneNumber,
                        Timestamps = new Timestamps
                        {
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    };
                }
                else
                {
                    newUser = new Client
                    {
                        Id = Guid.NewGuid(),
                        Profile = userProfile,
                        PhoneNumber = request.PhoneNumber,
                        Timestamps = new Timestamps
                        {
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    };
                }
                var cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = newUser.Id,
                    Items = [],
                    User = newUser,
                    Timestamps = new Timestamps
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                };

                await _dbContext.Users.AddAsync(newUser, cancellationToken);
                await _dbContext.Carts.AddAsync(cart, cancellationToken);


                user = newUser;
            }
            user.Profile.Name = request.Name ?? user.Profile.Name;
            if (request.FncToken != null && !user.FncTokens.Select(e => e.Value).Contains(request.FncToken))
                user.FncTokens.Add(new FncToken { Value = request.FncToken, User = user });
            token = _jwtProvider.Generate(user);
            verification.CanLogin = false;
            verification.CheckId = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return token;
        }
    }
}
