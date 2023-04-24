using BankSystem.Application.Services;
using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Commands
{
    public class DeleteUserAccountCommandHandler : IRequestHandler<DeleteUserAccountCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityService _userIdentityService;
        public DeleteUserAccountCommandHandler(
            IUserRepository userRepository,
            IUserIdentityService userIdentityService)
        {
            _userRepository = userRepository;
            _userIdentityService = userIdentityService;
        }

        public async Task<bool> Handle(DeleteUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userId = _userIdentityService.GetUserId();
            var user = await _userRepository.GetById(userId);
            ArgumentNullException.ThrowIfNull(user);

            var result = user.DeleteAccount(request.AccountId);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;

        }
    }
}
