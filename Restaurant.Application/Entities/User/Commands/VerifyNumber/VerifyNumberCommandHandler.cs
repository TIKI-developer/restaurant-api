using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands.VerifyNumber
{
    public class VerifyNumberCommandHandler
        (IRestaurantDbContext dbContext,
        INumberVerifier numberVerifier) 
        : 
        IRequestHandler<VerifyNumberCommand>
    {
        private readonly IRestaurantDbContext _dbContext =  dbContext;
        private readonly INumberVerifier _numberVerifier = numberVerifier;

        public async Task Handle(VerifyNumberCommand request, CancellationToken cancellationToken)
        {
            var checkId = _numberVerifier.Verify(request.Data, request.Hash);

            var verification = await
                _dbContext
                .Verifications
                .FirstOrDefaultAsync(v => v.CheckId == checkId, cancellationToken);

            if (verification != null)
            {
                verification.CanLogin = true;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
