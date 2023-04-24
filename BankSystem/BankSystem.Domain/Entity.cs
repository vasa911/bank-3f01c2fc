namespace BankSystem.Domain
{
    public class Entity
    {
        int id;
        public virtual int Id
        {
            get => id;
            protected set => id = value;
        }
    }
}