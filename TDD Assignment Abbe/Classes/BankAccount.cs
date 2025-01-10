using System;

namespace TDD_Assignment_Abbe.Classes
{
    public class BankAccount
    {
        // Holds the current account balance
        private decimal _balance;

        // Property to get the current balance
        public decimal Balance => _balance;

        // Adds the specified amount to the balance
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            _balance += amount;
        }

        // Deducts the specified amount from the balance
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }

            _balance -= amount;
        }
    }
}

