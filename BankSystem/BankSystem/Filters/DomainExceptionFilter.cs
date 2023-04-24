using BankSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankSystem.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<DomainExceptionFilter> logger;

        public DomainExceptionFilter(ILogger<DomainExceptionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException domainException)
            {
                this.logger.LogError(domainException, domainException.Message);
                context.Result = new JsonResult(new { message = domainException.Message })
                {
                    StatusCode = 400
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
