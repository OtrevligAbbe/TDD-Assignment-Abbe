using System;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_IncreasesBalanceCorrectly()
        {
            // Arrange
            var account = new BankAccount();
            decimal depositAmount = 100m;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.Equal(depositAmount, account.Balance);
        }

        [Fact]
        public void Withdraw_DecreasesBalanceCorrectly()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(200m);
            decimal withdrawAmount = 50m;

            // Act
            account.Withdraw(withdrawAmount);

            // Assert
            Assert.Equal(150m, account.Balance);
        }

        [Fact]
        public void Withdraw_ThrowsException_WhenAmountExceedsBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(150m));
        }

        [Fact]
        public void Deposit_ThrowsException_WhenAmountIsNegative()
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(-50m));
        }

        [Fact]
        public void Withdraw_ThrowsException_WhenAmountIsNegative()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(-20m));
        }

        [Fact]
        public void Withdraw_ThrowsException_WhenAmountIsZero()
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(0m));
        }

        [Fact]
        public void Deposit_ThrowsException_WhenAmountIsZero()
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(0m));
        }
    }
}
