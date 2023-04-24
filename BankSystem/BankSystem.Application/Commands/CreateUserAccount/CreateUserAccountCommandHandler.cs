using BankSystem.Application.Services;
using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityService _userIdentityService;
        public CreateUserAccountCommandHandler(
            IUserRepository userRepository, 
            IUserIdentityService userIdentityService)
        {
            _userRepository = userRepository;
            _userIdentityService = userIdentityService;
        }

        public async Task<Guid> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userId = _userIdentityService.GetUserId();
            var user = await _userRepository.GetById(userId);
            ArgumentNullException.ThrowIfNull(user);

            var newAccount = user.CreateAccount(request.Name);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newAccount.Id;
        }
    }
}
