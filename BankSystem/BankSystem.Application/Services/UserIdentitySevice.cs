namespace BankSystem.Application.Services
{
    /// <summary>
    /// Service for retrieving user data from token/cookie
    /// </summary>
    public class UserIdentitySevice : IUserIdentityService
    {
        /// <summary>
        /// Retrieves User identificator
        /// Just a stub for now
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Guid GetUserId()
        {
            return new Guid("797c5451-93e9-4af8-86e7-4b440172dea4");
        }
    }
}
