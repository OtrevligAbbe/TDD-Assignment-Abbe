
# TDD Assignment Abbe 📚

Welcome to the **TDD Assignment Abbe** repository! This project demonstrates the principles of **Test-Driven Development (TDD)** with a focus on various functionalities like inventory management, string processing, banking operations, and booking systems.

---

## Features ✨

### Inventory Management
- Add, remove, and track items in an inventory.
- Check for out-of-stock items.

### String Processor
- Sanitize strings, remove unwanted characters, and perform case conversions.
- Compare strings with various criteria.

### Bank Account
- Handle deposits, withdrawals, and balance checks.
- Includes validation for negative or zero transactions.

### Weather Client
- Fetch current weather data asynchronously.
- Handle HTTP requests with mock responses.

### Booking System 🗓️
- Manage bookings with available time slots.
- Includes:
  - **BookingSystem**: Core logic for booking operations.
  - **BookingServiceFacade**: Simplified interface for managing bookings.
  - Tests implemented using **xUnit**.

---

## Technology Stack 🛠️
- **C#**: The programming language.
- **xUnit**: Testing framework.
- **Moq**: For mocking dependencies in tests.

---

## Folder Structure 📂
```plaintext
.
├── Classes
│   ├── BankAccount.cs
│   ├── BookingSystem.cs
│   ├── Calculator.cs
│   ├── InventoryManager.cs
│   ├── ObjectValidator.cs
│   ├── StringProcessor.cs
│   ├── WeatherClient.cs
├── Facade
│   ├── BookingSystemFacade.cs
│   └── WeatherClientFacade.cs
├── Test
│   ├── BankAccountTest.cs
│   ├── BookingSystemTest.cs
│   ├── BookingSystemFacadeTest.cs
│   ├── CalculatorTest.cs
│   ├── InventoryManagerTest.cs
│   ├── ObjectValidatorTest.cs
│   ├── StringProcessorTest.cs
│   └── WeatherClientTest.cs
├── TestHelpers
│   └── MockHttpMessageHandler.cs
└── README.md
```

---

## How to Run 🚀

1. **Clone the repository**:
   ```bash
   git clone https://github.com/username/TDD-Assignment-Abbe.git
   ```
2. **Open the solution** in Visual Studio.
3. **Build the solution** to restore dependencies.
4. **Run all tests** using the Test Explorer.

---

## Tests 🧪

- Tests are written for all major components using **xUnit**.
- Includes **mocking** for external dependencies.
- To run tests:
  1. Open the Test Explorer in Visual Studio.
  2. Run all tests.

---

## License 📜

This project is licensed under the MIT License.
