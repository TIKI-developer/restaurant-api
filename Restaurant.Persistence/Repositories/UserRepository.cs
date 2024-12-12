using Restaurant.Application.Interfaces;
using Restaurant.Application.Interfaces.Repositories;
using Restaurant.Domain;

namespace Restaurant.Persistence.Repositories
{
    internal class UserRepository(IRestaurantDbContext dbContext) : IUserRepository
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByNumberAsync(string number, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(string number, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
