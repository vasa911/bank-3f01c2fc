using BankSystem.Application.Services;
using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands
{
    public class WithdrawUserAccountCommandHandler : IRequestHandler<WithdrawUserAccountCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityService _userIdentityService;
        public WithdrawUserAccountCommandHandler(
            IUserRepository userRepository,
            IUserIdentityService userIdentityService)
        {
            _userRepository = userRepository;
            _userIdentityService = userIdentityService;
        }

        public async Task<bool> Handle(WithdrawUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userId = _userIdentityService.GetUserId();
            var user = await _userRepository.GetById(userId);
            ArgumentNullException.ThrowIfNull(user);

            var result = user.WithdrawAccount(request.AccountId, request.Amount);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
