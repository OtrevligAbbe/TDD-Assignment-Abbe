using System;

namespace TDD_Assignment_Abbe.Classes
{
    public class BankAccount
    {
        // Privat fält för att hålla saldot
        private decimal _balance;

        // Publik egenskap för att läsa saldot
        public decimal Balance
        {
            get { return _balance; }
        }

        // Metod för att sätta in pengar
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            _balance += amount;
        }

        // Metod för att ta ut pengar
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
