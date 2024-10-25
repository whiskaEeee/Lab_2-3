using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Interfaces;

namespace Testing.Implementations
{
    public class SimpleCalculator : ICalculator
    {
        public double Sum(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (Math.Abs(b) < 1e-8)
            {
                throw new ArithmeticException("Division by a value close to zero is not allowed.");
            }
            return a / b;
        }
    }
}
