using MediatR;

namespace BankSystem.Application.Commands
{
    public class CreateUserAccount : IRequest
    {
        public string Name { get; }
        public CreateUserAccount(string name)
        {
            Name = name;
        }
    }
}
