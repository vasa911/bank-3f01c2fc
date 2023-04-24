namespace BankSystem.Domain.Exceptions
{
    public class DepositDomainException : DomainException
    {
        public decimal Amount { get; }
        public decimal MaxAmount { get;}
        public DepositDomainException(decimal amount, decimal maxAmount)
        {
            Amount = amount;
            MaxAmount= maxAmount;
        }

        public override string Message => $"Can't deposit (${Amount}) for account as it's more than limit (${MaxAmount}) for single transaction.";
    }
}
