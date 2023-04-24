using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Domain.Aggregates.User
{
    public class Account : Entity
    {
        [MaxLength(10)]
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        public Guid UserId { get; private set; }
        public virtual User User { get; set; }

        public Account(string name)
        {
            Name = name;
            Balance = 100;
        }
    }
}
