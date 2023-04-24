using BankSystem.Domain.Exceptions;
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



        public const decimal MaxDepositAmount = 10000;

        public Account(string name)
        {
            Name = name;
            Balance = 100;
        }


        public void Deposit(decimal amount)
        {
            if (amount > MaxDepositAmount)
            {
                throw new DepositDomainException(amount, MaxDepositAmount);
            }
            Balance += amount;
        }
    }
}
