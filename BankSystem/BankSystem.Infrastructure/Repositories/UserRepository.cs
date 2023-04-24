using BankSystem.Domain.Aggregates.User;
using BankSystem.Infrastructure.Interfaces;

namespace BankSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(BankContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User User)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
