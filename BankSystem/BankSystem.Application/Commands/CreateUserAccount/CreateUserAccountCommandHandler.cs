using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = await _userRepository.GetById(id);
            user.CreateAccount(request.Name);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
