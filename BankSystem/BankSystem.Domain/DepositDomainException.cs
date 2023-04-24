namespace BankSystem.Domain
{
    public class DepositDomainException : Exception
    {
        public DepositDomainException()
        { }

        public DepositDomainException(string message)
            : base(message)
        { }

        public DepositDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
