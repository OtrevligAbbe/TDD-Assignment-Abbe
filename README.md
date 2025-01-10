
# TDD Assignment Abbe

🎉 Welcome to the **TDD Assignment Abbe** project! This repository contains a collection of test-driven development (TDD) assignments with various classes and tests implemented using xUnit.

## 📚 Project Structure

### Classes
- `BankAccount.cs`: Manages deposits and withdrawals with balance checks.
- `BookingSystem.cs`: Handles booking time slots and retrieving available time slots.
- `Calculator.cs`: Performs basic arithmetic operations.
- `InventoryManager.cs`: Manages inventory items, their quantities, and stock statuses.
- `ObjectValidator.cs`: Validates objects for null values and retrieves null properties.
- `StringProcessor.cs`: Processes strings with various utility methods.
- `WeatherClient.cs`: Retrieves current weather conditions using a facade pattern.

### Facades
- `BookingSystemFacade.cs`: Acts as an interface for managing bookings with `BookingSystem`.

### Tests
- `BankAccountTest.cs`: Validates `BankAccount` functionality.
- `BookingSystemTest.cs`: Tests the booking system's core features.
- `CalculatorTest.cs`: Ensures correct operations in `Calculator`.
- `InventoryManagerTest.cs`: Covers inventory management operations.
- `ObjectValidatorTest.cs`: Validates `ObjectValidator` methods.
- `StringProcessorTest.cs`: Ensures string operations are functioning as expected.
- `WeatherClientTest.cs`: Mocks and tests weather client interactions.
- `BookingSystemFacadeTest.cs`: Tests the facade's ability to interact with `BookingSystem`.

## 🛠️ Features Added
### Booking System
- Added `BookingSystemFacade.cs` to streamline booking operations.
- Added comprehensive tests in `BookingSystemFacadeTest.cs`.

### Null Object Validation
- `ObjectValidator.cs`: Validates objects for null properties and provides a list of null fields.

## 🚀 Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- IDE (e.g., Visual Studio, Rider)
- xUnit Test Runner

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/TDD-Assignment-Abbe.git
   cd TDD-Assignment-Abbe
   ```

2. Build the solution:
   ```bash
   dotnet build
   ```

3. Run tests:
   ```bash
   dotnet test
   ```

### Usage
- Modify or add features as needed.
- Run tests frequently to ensure functionality.

## 🤝 Contributing
Contributions are welcome! Feel free to submit pull requests or raise issues.

## 📝 License
This project is licensed under the MIT License.

---

💻 Happy Coding! 🎉
