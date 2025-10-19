# Calculator Application

A simple calculator application built with C# and .NET Core, demonstrating separation of concerns with multiple assemblies.

## Project Structure

The solution consists of three separate assemblies:

### 1. Calculator.BusinessLogic
Class library containing the calculator business logic and user settings management.
- **Calculator.cs** - Core calculator operations (Add, Subtract, Multiply, Divide)
- **UserSettings.cs** - Windows Registry integration for storing user name settings

### 2. Calculator.CLI
Command-line executable application with a text-based user interface.
- Interactive calculator interface
- User name storage and retrieval using Windows Registry
- Menu-driven operation selection

### 3. Calculator.Tests
xUnit test project for testing the business logic.
- Comprehensive unit tests for all calculator operations
- Tests for edge cases (division by zero, negative numbers, etc.)

## Technologies Used

- **C# and .NET Core** (targeting .NET 9.0)
- **Microsoft.Windows.Compatibility** package for Windows Registry access
- **xUnit** for unit testing

## Building the Solution

```bash
dotnet build Calculator.sln
```

## Running Tests

```bash
dotnet test Calculator.sln
```

## Running the Calculator

```bash
dotnet run --project Calculator.CLI
```

Or directly execute the built binary:
```bash
./Calculator.CLI/bin/Debug/net9.0/Calculator.CLI
```

## Features

- Basic arithmetic operations (addition, subtraction, multiplication, division)
- User name persistence using Windows Registry
- Input validation and error handling
- Division by zero protection
- Interactive command-line interface

## Windows Registry Storage

The user name setting is stored in the Windows Registry at:
```
HKEY_CURRENT_USER\SOFTWARE\Calculator\UserName
```

Note: This feature is Windows-specific and uses the Microsoft.Windows.Compatibility package.