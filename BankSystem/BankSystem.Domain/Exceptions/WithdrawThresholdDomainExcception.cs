namespace BankSystem.Domain.Exceptions
{
    public class WithdrawThresholdDomainExcception : DomainException
    {
        public double MaxAmount { get; }
        public WithdrawThresholdDomainExcception(double maxAmount)
        {
            MaxAmount = maxAmount * 100;
        }

        public override string Message => $"Can't withdraw more than {MaxAmount}% of total balance from account in a single transaction.";
    }
}
