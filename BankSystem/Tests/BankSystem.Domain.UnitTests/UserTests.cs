using BankSystem.Domain.Aggregates.User;

namespace BankSystem.Domain.UnitTests
{
    public class UserTests
    {
        private readonly User _user;

        public UserTests()
        {
            _user = new User("TestUser");
        }

        [Fact]
        public void CreateAccount_NewAccount_AccountCreated()
        {
            // arrange
            string accountName = "TestAccount";

            // act
            Account account = _user.CreateAccount(accountName);

            // assert
            Assert.NotNull(account);
            Assert.Equal(accountName, account.Name);
            Assert.Contains(account, _user.Accounts);
        }

        [Fact]
        public void DeleteAccount_ExistingAccount_AccountRemoved()
        {
            // arrange
            Account accountToDelete = _user.CreateAccount("TestAccount");
            int accountsCount = _user.Accounts.Count;

            // act
            bool success = _user.DeleteAccount(accountToDelete.Id);

            // assert
            Assert.True(success);
            Assert.Equal(accountsCount - 1, _user.Accounts.Count);
            Assert.DoesNotContain(accountToDelete, _user.Accounts);
        }

        [Fact]
        public void DeleteAccount_NonExistingAccount_ReturnsFalse()
        {
            // arrange
            Guid nonExistingAccountId = Guid.NewGuid();
            int accountsCount = _user.Accounts.Count;

            // act
            bool result = _user.DeleteAccount(nonExistingAccountId);

            // assert
            Assert.False(result);
            Assert.Equal(accountsCount, _user.Accounts.Count);
        }

        [Fact]
        public void DepositAccount_InvalidAmount_ReturnFalse()
        {
            // arrange
            decimal amount = -10;
            Account account = _user.CreateAccount("TestAccount");

            // act
            bool result = _user.DepositAccount(account.Id, amount);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void WithdrawAccount_InvalidAmount_ReturnFalse()
        {
            // arrange
            decimal amount = -10;
            Account account = _user.CreateAccount("TestAccount");

            // act
            bool result = _user.WithdrawAccount(account.Id, amount);

            // assert
            Assert.False(result);
        }

    }
}
