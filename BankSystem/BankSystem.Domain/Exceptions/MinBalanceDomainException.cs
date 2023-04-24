using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Exceptions
{
    public class MinBalanceDomainException : DomainException
    {
        public decimal MinAmount { get; }
        public MinBalanceDomainException(decimal maxAmount)
        {
            MinAmount = maxAmount;
        }

        public override string Message => $"An account cannot have less than ${MinAmount} at any time.";
    }
}
