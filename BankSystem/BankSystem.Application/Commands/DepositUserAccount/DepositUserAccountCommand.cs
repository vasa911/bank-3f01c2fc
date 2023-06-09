﻿using MediatR;

namespace BankSystem.Application.Commands
{
    public class DepositUserAccountCommand : IRequest<bool>
    {
        public Guid AccountId { get; }
        public decimal Amount { get; }

        public DepositUserAccountCommand(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
