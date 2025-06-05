using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class PrepareVerificationPhoneNumberCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<PrepareVerificationPhoneNumberCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(PrepareVerificationPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var verification = await
                _dbContext
                .Verifications
                .Include(e => e.Timestamps)
                .FirstOrDefaultAsync(v => v.Number == request.Number, cancellationToken);

            if (verification == null)
            {
                var newVerification = new Verification
                {
                    Number = request.Number,
                    CheckId = request.CheckId,
                    CanLogin = false,
                    Timestamps = new Timestamps
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                };

                await _dbContext.Verifications.AddAsync(newVerification, cancellationToken);
            }
            else
            {
                verification.Number = request.Number;
                verification.CheckId = request.CheckId;
                verification.CanLogin = false;
                verification.Timestamps.UpdatedAt = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
