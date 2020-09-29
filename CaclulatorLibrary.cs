using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        
        public Calculator()
        // Constructor (initiate logging)
        {
            // .json logging
            StreamWriter logFile = File.CreateText("calculator.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
            // .txt logging
            /*
            StreamWriter logFile = File.CreateText("calculator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting Calculator Log");
            Trace.WriteLine(String.Format($"Started {System.DateTime.Now.ToString()}"));
            */
        }

        // Function/method for completing calculation.
        public double Calculation(double num1, double num2, string op)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Number1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Number2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            switch (op) {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    // For .txt as below:
                    // Trace.WriteLine(String.Format($"{num1} + {num2} = {result}"));
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    // For .txt as below:
                    // Trace.WriteLine(String.Format($"{num1} - {num2} = {result}"));
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    // For .txt as below:
                    // Trace.WriteLine(String.Format($"{num1} * {num2} = {result}"));
                    break;
                case "d":
                    while (num2 == 0) {
                        Console.WriteLine("Can't divide by 0, enter another denominator:");
                        num2 = Convert.ToDouble(Console.ReadLine());
                    }
                    result = num1 / num2;
                    writer.WriteValue("Divide");
                    // For .txt as below:
                    // Trace.WriteLine(String.Format($"{num1} / {num2} = {result}"));
                    break;
                default:
                    Console.WriteLine($"Error: {op} is not an accepted operator.");
                    break;                
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}