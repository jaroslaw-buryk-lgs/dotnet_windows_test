using System.Runtime.InteropServices;
using Calculator.BusinessLogic;

namespace Calculator.CLI;

class Program
{
    static void Main(string[] args)
    {
        var calculator = new BusinessLogic.Calculator();
        var userSettings = new UserSettings();

        // Get or set user name
        string? userName = userSettings.GetUserName();
        if (string.IsNullOrEmpty(userName))
        {
            Console.Write("Welcome! Please enter your name: ");
            userName = Console.ReadLine();
            if (!string.IsNullOrEmpty(userName))
            {
                userSettings.SetUserName(userName);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Console.WriteLine($"Hello, {userName}! Your name has been saved to Windows Registry.");
                }
                else
                {
                    Console.WriteLine($"Hello, {userName}! (Note: Registry storage is only available on Windows)");
                }
            }
        }
        else
        {
            Console.WriteLine($"Welcome back, {userName}!");
        }

        Console.WriteLine("\nSimple Calculator");
        Console.WriteLine("=================");

        while (true)
        {
            try
            {
                Console.WriteLine("\nAvailable operations:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Change user name");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect operation (1-6): ");

                string? choice = Console.ReadLine();

                if (choice == "6")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (choice == "5")
                {
                    Console.Write("Enter new name: ");
                    string? newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        userSettings.SetUserName(newName);
                        userName = newName;
                        Console.WriteLine($"Name changed to {userName}");
                    }
                    continue;
                }

                Console.Write("Enter first number: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                Console.Write("Enter second number: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                double result = choice switch
                {
                    "1" => calculator.Add(num1, num2),
                    "2" => calculator.Subtract(num1, num2),
                    "3" => calculator.Multiply(num1, num2),
                    "4" => calculator.Divide(num1, num2),
                    _ => throw new InvalidOperationException("Invalid choice")
                };

                Console.WriteLine($"\nResult: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
