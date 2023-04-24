namespace BankSystem.Domain.Aggregates.User
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; }

        public virtual List<Account> Accounts { get; }

        public User(string name) 
        {
            Name = name;
            Accounts= new List<Account>();
        }
    }
}
