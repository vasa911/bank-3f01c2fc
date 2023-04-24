using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = await _userRepository.GetById(id);
            var newAccount = user.CreateAccount(request.Name);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newAccount.Id;
        }
    }
}
