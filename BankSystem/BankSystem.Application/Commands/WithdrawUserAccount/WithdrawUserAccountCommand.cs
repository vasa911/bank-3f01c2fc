using MediatR;

namespace BankSystem.Application.Commands
{
    public class WithdrawUserAccountCommand : IRequest<bool>
    {
        public Guid AccountId { get; }
        public decimal Amount { get; }

        public WithdrawUserAccountCommand(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
