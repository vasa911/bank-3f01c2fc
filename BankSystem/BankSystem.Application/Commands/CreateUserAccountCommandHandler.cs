using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccount>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserAccount request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = await _userRepository.GetById(id);
        }
    }
}
