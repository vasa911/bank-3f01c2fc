using MediatR;

namespace BankSystem.Application.Commands.CreateUserAccount
{
    public class CreateUserAccountCommand : IRequest
    {
        public string Name { get; }
        public CreateUserAccountCommand(string name)
        {
            Name = name;
        }
    }
}
