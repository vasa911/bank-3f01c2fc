namespace BankSystem.Domain.Aggregates.User
{
    public class Account : Entity
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public Account(string name)
        {
            Name = name;
        }
    }
}
