using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Interfaces;

namespace Testing.Implementations
{
    public class CalculatorViewImpl : ICalculatorView
    {

        public string GetFirstArgumentAsString()
        {

            return "10";
        }

        public string GetSecondArgumentAsString()
        {

            return "20";
        }

        public void PrintResult(double result)
        {
            Console.WriteLine($"Result: {result}");
        }

        public void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }

}
