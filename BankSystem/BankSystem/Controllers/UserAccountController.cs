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

        [HttpPost(Name = "AddUserAccount")]
        public Task<bool> Add(string name)
        {

            //create account
            return Task.FromResult(true);
        }
    }
}