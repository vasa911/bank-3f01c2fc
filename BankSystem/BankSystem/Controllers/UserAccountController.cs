using BankSystem.Application.Commands;
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

        [HttpGet]
        public async Task<IEnumerable<UserAccount>> Get()
        {
            return await _mediator.Send(new GetUserAccountsQuery());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserAccountCommand request)
        {
            var accountId = await _mediator.Send(request);
            return Ok(new { accountId });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserAccountCommand(id));
            return Ok(new { result });
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositUserAccountCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new { result });
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawUserAccountCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new { result });
        }
    }
}