using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {

        private readonly ILogger<UserAccountController> _logger;

        public UserAccountController(ILogger<UserAccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CreateUserAccount")]
        public Task<bool> Create(string name)
        {

            //create account
            return Task.FromResult(true);
        }
    }
}