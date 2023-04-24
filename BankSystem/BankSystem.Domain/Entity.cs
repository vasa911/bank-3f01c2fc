namespace BankSystem.Domain
{
    public class Entity
    {
        Guid id;
        public virtual Guid Id
        {
            get => id;
            protected set => id = value;
        }
    }
}