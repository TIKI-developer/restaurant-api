using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
using Restaurant.Domain.User;
using Restaurant.Domain.User.Admin;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.User.Commands.Login
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
            request.Number = NormalizePhoneNumber(request.Number);

            var verification = await
                _dbContext
                .Verifications
                .FirstOrDefaultAsync(v => v.Number == request.Number, cancellationToken);

            if (verification == null || string.IsNullOrEmpty(verification.CheckId) || !verification.CanLogin)
            {
                throw new Exception("Verification failed!");
            }

            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(user => user.Number == request.Number, cancellationToken);

            string token;

            if (user == null)
            {
                var userProfile = new UserModel.ProfileModel
                {
                    Name = request.Name
                };
                UserModel newUser;

                if (_adminIdentityProvider.IsAdmin(request))
                {
                    newUser = new AdminModel
                    {
                        Id = Guid.NewGuid(),
                        Profile = userProfile,
                        Number = request.Number,
                    };
                }
                else
                {
                    newUser = new ClientModel
                    {
                        Id = Guid.NewGuid(),
                        Profile = userProfile,
                        Number = request.Number,
                    };
                }
                var cart = new CartModel
                {
                    UserId = newUser.Id,
                    Items = [],
                    User = newUser
                };

                await _dbContext.Users.AddAsync(newUser, cancellationToken);
                await _dbContext.Carts.AddAsync(cart, cancellationToken);


                user = newUser;
            }

            token = _jwtProvider.Generate(user);
            verification.CanLogin = false;
            verification.CheckId = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return token;
        }
        private string NormalizePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("89"))
            {
                return "+7" + phoneNumber.Substring(1);
            }
            return phoneNumber;
        }
    }
}
