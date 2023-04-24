using System.ComponentModel.DataAnnotations;

namespace BankSystem.Domain.Aggregates.User
{
    public class User : Entity, IAggregateRoot
    {
        [MaxLength(50)]
        public string Name { get; }

        public virtual ICollection<Account> Accounts { get; }


        protected User()
        {
            Accounts = new List<Account>();
        }
        /// <summary>
        /// Added only for test assesment purpose
        /// to have pressed users
        /// </summary>
        public User(Guid id, string name) : this(name)
        {
            Id = id;
        }

        public User(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public Account CreateAccount(string accountName)
        {
            var account = new Account(accountName);
            Accounts.Add(account);
            return account;
        }

        public bool DeleteAccount(Guid accountId)
        {
            var accountToDelete = Accounts.FirstOrDefault(x => x.Id == accountId);
            if (accountToDelete == null) { return false; }
            return Accounts.Remove(accountToDelete);
        }

        public bool DepositAccount(Guid accountId, decimal amount)
        {
            if (!CheckPositiveAmount(amount)) return false;
            var account = Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account == null) { return false; }

            account.Deposit(amount);

            return true;
        }

        public bool WithdrawAccount(Guid accountId, decimal amount)
        {
            if (!CheckPositiveAmount(amount)) return false;
            var account = Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account == null) { return false; }

            account.Withdraw(amount);

            return true;
        }

        private bool CheckPositiveAmount(decimal amount)
        {
            return amount > 0;
        }
    }
}
