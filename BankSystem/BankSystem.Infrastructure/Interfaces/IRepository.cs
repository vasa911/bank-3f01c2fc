using BankSystem.Domain;

namespace BankSystem.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
