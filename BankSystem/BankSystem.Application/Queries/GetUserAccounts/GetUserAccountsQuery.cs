using BankSystem.Application.Models;
using MediatR;

namespace BankSystem.Application.Queries.GetUserAccounts
{
    public class GetUserAccountsQuery : IRequest<IEnumerable<UserAccount>>
    {
    }
}
