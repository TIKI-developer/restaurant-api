using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.User.Commands.VerifyNumber
{
    public class PrepareVerifyNumberCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<PrepareVerifyNumberCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(PrepareVerifyNumberCommand request, CancellationToken cancellationToken)
        {
            var verification = await
                _dbContext
                .Verifications
                .FirstOrDefaultAsync(v => v.Number == request.Number, cancellationToken);

            if (verification == null) 
            {
                var newVerification = new VerificationModel
                {
                    Number = request.Number,
                    CheckId = request.CheckId,
                    CanLogin = false
                };

                await _dbContext.Verifications.AddAsync(newVerification, cancellationToken);
            }
            else
            {
                verification.Number = request.Number;
                verification.CheckId = request.CheckId;
                verification.CanLogin = false;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
