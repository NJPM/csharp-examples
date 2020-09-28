using System;

namespace myApp
{
    class Calculator
    {
        public static double Calculation(double num1, double num2, string op)
        {
            double result = double.NaN;

            switch (op) {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    while (num2 == 0) {
                        Console.WriteLine("Can't divide by 0, enter another denominator:");
                        num2 = Convert.ToDouble(Console.ReadLine());
                    }
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine($"Error: {op} is not an accepted operator.");
                    break;                
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            // Title
            Console.WriteLine("Simple C# Calculator");
            Console.WriteLine("--------------------");

            while (!endApp) {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // User input 1st number
                Console.WriteLine("Enter your first number:");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1)) {
                    Console.WriteLine($"{numInput1} is not a number, please enter a number:");
                    numInput1 = Console.ReadLine();
                }

                // User input 2nd number
                Console.WriteLine("Enter your second number:");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) {
                    Console.WriteLine($"{numInput2} is not a number, please enter a number:");
                    numInput2 = Console.ReadLine();
                }

                // User input operator
                Console.WriteLine("Enter an operator:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");

                string op = Console.ReadLine();
                string opSymbol = "";
                switch (op) {
                    case "a":
                        opSymbol = "+";
                        break;
                    case "s":
                        opSymbol = "-";
                        break;
                    case "m":
                        opSymbol = "*";
                        break;
                    case "d":
                        opSymbol = "/";
                        break;
                }

                // Calc
                try {
                    result = Calculator.Calculation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) {
                        Console.WriteLine("Mathematical error in calculation, try another calculation.");
                    } else {
                        Console.WriteLine($"{cleanNum1} {opSymbol} {cleanNum2} = " + "{0:0.##}", result);
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Exception: " + e.Message);
                }
                Console.WriteLine("-------------------");

                // Restart or close
                Console.WriteLine("Restart calculator? y/n");
                if (Console.ReadLine() != "y") endApp = true;
                }
                return;
        }
    }
}
