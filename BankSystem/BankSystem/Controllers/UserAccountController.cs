using BankSystem.Application.Commands.CreateUserAccount;
using BankSystem.Application.Models;
using BankSystem.Application.Queries.GetUserAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IMediator _mediator;

        public UserAccountController(
            ILogger<UserAccountController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUserAccounts")]
        public async Task<IEnumerable<UserAccount>> Get()
        {
            return await _mediator.Send(new GetUserAccountsQuery());
        }


        [HttpPost(Name = "CreateUserAccount")]
        public async Task<IActionResult> Create([FromBody] CreateUserAccountCommand request)
        {
            var accountId = await _mediator.Send(request);
            return Ok(new { accountId });
        }
    }
}