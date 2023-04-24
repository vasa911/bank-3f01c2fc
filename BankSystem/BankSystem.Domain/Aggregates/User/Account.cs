using System.ComponentModel.DataAnnotations;

namespace BankSystem.Domain.Aggregates.User
{
    public class Account : Entity
    {
        [MaxLength(10)]
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string name)
        {
            Name = name;
            Balance = 100;
        }
    }
}
