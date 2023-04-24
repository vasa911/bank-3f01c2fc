using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Services
{
    public interface IUserIdentityService
    {
        Guid GetUserId();
    }
}
