using AutoMapper;
using BankSystem.Application.Services;
using BankSystem.Infrastructure.Repositories;
using MediatR;

namespace BankSystem.Application.Queries.GetUserAccounts
{
    public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, IEnumerable<Models.UserAccount>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityService _userIdentityService;
        private readonly IMapper _mapper;

        public GetUserAccountsQueryHandler(
            IUserRepository userRepository,
            IUserIdentityService userIdentityService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userIdentityService = userIdentityService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Models.UserAccount>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userIdentityService.GetUserId();
            var user = await _userRepository.GetById(userId);
            ArgumentNullException.ThrowIfNull(user);

            var accounts = _mapper.Map<IEnumerable<Models.UserAccount>>(user.Accounts);

            return accounts;
        }
    }
}
