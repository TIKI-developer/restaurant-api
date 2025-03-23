using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Entities.User.Commands.CodeCall
{
    public class CodeCallCommandHandler 
        (IRestaurantDbContext dbContext)
        : IRequestHandler<CodeCallCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(CodeCallCommand request, CancellationToken cancellationToken)
        {
            var verification = await
                _dbContext
                .Verifications
                .FirstOrDefaultAsync(e => e.Number == request.PhoneNumber, cancellationToken);

            if (verification == null)
            {
                var newVerification = new Verification
                {
                    Number = request.PhoneNumber,
                    CanLogin = false,
                    CallCode = request.Code,
                    CallId = request.CallId,
                    Timestamps = new Timestamps
                    { CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                };

                await _dbContext.Verifications.AddAsync(newVerification, cancellationToken);
            } 
            else
            {
                verification.Number = request.PhoneNumber;
                verification.CanLogin = false;
                verification.CallCode = request.Code;
                verification.CallId = request.CallId;
                verification.Timestamps.UpdatedAt = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
