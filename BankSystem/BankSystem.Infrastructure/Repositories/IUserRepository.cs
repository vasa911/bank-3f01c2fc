using BankSystem.Domain.Aggregates.User;
using BankSystem.Infrastructure.Interfaces;

namespace BankSystem.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);
        bool Delete(User User);
        Task<User> FindByIdAsync(int id);
    }
}
