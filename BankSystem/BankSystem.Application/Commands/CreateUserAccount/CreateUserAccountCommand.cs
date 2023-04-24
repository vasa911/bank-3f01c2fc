using MediatR;

namespace BankSystem.Application.Commands
{
    public class CreateUserAccountCommand : IRequest<Guid>
    {
        public string Name { get; }
        public CreateUserAccountCommand(string name)
        {
            Name = name;
        }
    }
}
