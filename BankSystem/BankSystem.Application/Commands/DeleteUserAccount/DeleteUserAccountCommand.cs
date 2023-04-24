using MediatR;

namespace BankSystem.Application.Commands
{
    public class DeleteUserAccountCommand : IRequest<bool>
    {
        public Guid AccountId { get; }

        public DeleteUserAccountCommand(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
