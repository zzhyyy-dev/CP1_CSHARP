using System;

class Program
{
    static void Main()
    {
        double result = 0;
        bool hasResult = false;
        string operationHistory = "";

        do
        {
            Console.Clear();
            Console.WriteLine("Calculator (Addition / Subtraction / Multiplication / Division)");
            Console.WriteLine("Current Operation: " + (string.IsNullOrEmpty(operationHistory) ? "None" : operationHistory));

            if (!hasResult)
            {
                Console.Write("Enter a number: ");
                if (!double.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Invalid input! Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                operationHistory = result.ToString();
                hasResult = true;
            }

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1 - Addition (+)");
            Console.WriteLine("2 - Subtraction (-)");
            Console.WriteLine("3 - Multiplication (*)");
            Console.WriteLine("4 - Division (/)");
            Console.WriteLine("5 - Clear operation");
            Console.WriteLine("6 - Show result (=)");

            Console.Write("Option: ");
            string input = Console.ReadLine().Trim();
            int option = input switch
            {
                "1" or "+" => 1,
                "2" or "-" => 2,
                "3" or "*" => 3,
                "4" or "/" => 4,
                "5" => 5,
                "6" or "=" => 6,
                _ => -1
            };

            if (option == -1)
            {
                Console.WriteLine("Invalid option! Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            if (option == 5)
            {
                result = 0;
                operationHistory = "";
                hasResult = false;
                Console.WriteLine("Operation cleared! Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            if (option == 6 && hasResult)
            {
                Console.WriteLine($"Current Result: {result}");
                Console.Write("Do you want to exit? (y/n): ");
                string exitChoice = Console.ReadLine().Trim().ToLower();
                if (exitChoice == "y")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                Console.Write("Do you want to continue with the same operation or start a new one? (same/new): ");
                string continueChoice = Console.ReadLine().Trim().ToLower();
                if (continueChoice == "new")
                {
                    result = 0;
                    operationHistory = "";
                    hasResult = false;
                    Console.WriteLine("Starting a new operation! Press any key to continue...");
                    Console.ReadKey();
                }
                continue;
            }

            Console.Write("Enter another number: ");
            if (!double.TryParse(Console.ReadLine(), out double newValue))
            {
                Console.WriteLine("Invalid input! Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            switch (option)
            {
                case 1:
                    result += newValue;
                    operationHistory += " + " + newValue;
                    break;
                case 2:
                    result -= newValue;
                    operationHistory += " - " + newValue;
                    break;
                case 3:
                    result *= newValue;
                    operationHistory += " * " + newValue;
                    break;
                case 4:
                    if (newValue == 0)
                    {
                        Console.WriteLine("Error: Division by zero!");
                        Console.ReadKey();
                        continue;
                    }
                    result /= newValue;
                    operationHistory += " / " + newValue;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                    continue;
            }
        } while (true);
    }
}
