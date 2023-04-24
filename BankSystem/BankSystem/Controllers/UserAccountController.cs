using BankSystem.Application.Commands.CreateUserAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {

        private readonly ILogger<UserAccountController> _logger;
        private readonly IMediator _mediatr;

        public UserAccountController(
            ILogger<UserAccountController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediatr = mediator;
        }

        [HttpPost(Name = "CreateUserAccount")]
        public async Task<IActionResult> Create([FromBody] CreateUserAccountCommand request)
        {
            var accountId = await _mediatr.Send(request);
            return Ok(new { accountId });
        }
    }
}