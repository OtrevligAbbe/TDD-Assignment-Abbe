using System;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{
    public class BankAccountTests
    {
        // Tests that depositing an amount increases the balance correctly
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

        // Tests that withdrawing an amount decreases the balance correctly
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

        // Tests that withdrawing more than the balance throws an exception
        [Fact]
        public void Withdraw_ThrowsException_WhenAmountExceedsBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(150m));
        }

        // Tests that depositing a negative amount throws an exception
        [Fact]
        public void Deposit_ThrowsException_WhenAmountIsNegative()
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(-50m));
        }

        // Tests that withdrawing a negative amount throws an exception
        [Fact]
        public void Withdraw_ThrowsException_WhenAmountIsNegative()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(-20m));
        }

        // Tests that withdrawing zero throws an exception
        [Fact]
        public void Withdraw_ThrowsException_WhenAmountIsZero()
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(0m));
        }

        // Tests that depositing zero throws an exception
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
