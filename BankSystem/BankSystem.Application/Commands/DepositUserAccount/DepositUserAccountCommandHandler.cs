using BankSystem.Application.Services;
using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands.DepositUserAccount
{
    public class DepositUserAccountCommandHandler : IRequestHandler<DepositUserAccountCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityService _userIdentityService;
        public DepositUserAccountCommandHandler(
            IUserRepository userRepository,
            IUserIdentityService userIdentityService)
        {
            _userRepository = userRepository;
            _userIdentityService = userIdentityService;
        }

        public async Task<bool> Handle(DepositUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userId = _userIdentityService.GetUserId();
            var user = await _userRepository.GetById(userId);
            ArgumentNullException.ThrowIfNull(user);

            var result = user.DepositAccount(request.AccountId, request.Amount);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
