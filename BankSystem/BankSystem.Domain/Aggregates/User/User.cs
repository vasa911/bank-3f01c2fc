using System.ComponentModel.DataAnnotations;

namespace BankSystem.Domain.Aggregates.User
{
    public class User : Entity, IAggregateRoot
    {
        [MaxLength(50)]
        public string Name { get; }

        public virtual List<Account> Accounts { get; }

        public User(string name) 
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public void CreateAccount(string accountName)
        {
            Accounts.Add(new Account(accountName));
        }
    }
}
