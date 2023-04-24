using BankSystem.Domain.Aggregates.User;
using BankSystem.Domain.Exceptions;

namespace BankSystem.Domain.UnitTests
{

    public class AccountTests
    {

        private readonly Account _account;

        public AccountTests()
        {
            _account = new Account("test");
        }

        [Fact]
        public void Constructor_BalanceIs100()
        {
            // arrange
            decimal expectedBalance = 100;

            // act
            var account = new Account("contstructor test");

            // assert
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        public void Deposit_ValidAmount_BalanceIncreased()
        {
            // arrange
            decimal amount = 50;
            decimal expectedBalance = _account.Balance + amount;

            // Act
            _account.Deposit(amount);

            // assert
            Assert.Equal(expectedBalance, _account.Balance);
        }

        [Fact]
        public void Deposit_MoreThanMaxAmount_ThrowsException()
        {
            // arrange
            decimal amount = Account.MaxDepositAmount + 100;

            // assert
            Assert.Throws<DepositDomainException>(() => _account.Deposit(amount));
        }

        [Fact]
        public void Withdraw_ValidAmount_BalanceDecreased()
        {
            // arrange
            decimal amount = 50;
            decimal depositAmount = 100; // we need balance more than MinBalance in order to Withdraw
            _account.Deposit(100);
            decimal expectedBalance = _account.Balance + depositAmount - amount;

            // Act
            _account.Withdraw(amount);

            // assert
            Assert.Equal(expectedBalance, _account.Balance);
        }

        [Fact]
        public void Withdraw_MoreThanMaxWithdrawThreshold_ThrowsWithdrawThresholdDomainExcception()
        {
            // arrange
            decimal amount = _account.Balance * (decimal)Account.MaxWithdrawThreshold + (decimal)0.05;

            // assert
            Assert.Throws<WithdrawThresholdDomainExcception>(() => _account.Withdraw(amount));
        }

        [Fact]
        public void Withdraw_BelowMinBalance_ThrowsMinBalanceDomainException()
        {
            // arrange
            decimal amount = _account.Balance - Account.MinBalance + 20;

            // assert
            Assert.Throws<MinBalanceDomainException>(() => _account.Withdraw(amount));
        }
    }
}