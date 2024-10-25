using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Implementations;
using Xunit;

namespace Testing.Tests
{

    public class SimpleCalculatorTests
    {
        private readonly SimpleCalculator calculator;

        public SimpleCalculatorTests()
        {
            calculator = new SimpleCalculator();
        }

        [Fact]
        public void Sum_WhenCalled_ReturnsCorrectSum()
        {
            double result = calculator.Sum(10, 20);

            Assert.Equal(30, result);
        }

        [Fact]
        public void Subtract_WhenCalled_ReturnsCorrectDifference()
        {
            double result = calculator.Subtract(20, 10);

            Assert.Equal(10, result);
        }

        [Fact]
        public void Multiply_WhenCalled_ReturnsCorrectProduct()
        {
            double result = calculator.Multiply(10, 20);

            Assert.Equal(200, result);
        }

        [Fact]
        public void Divide_WhenCalled_ReturnsCorrectQuotient()
        {
            double result = calculator.Divide(20, 10);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Divide_WhenDividingByNearZero_ThrowsArithmeticException()
        {
            Assert.Throws<ArithmeticException>(() => calculator.Divide(10, 1e-9));
        }
    }

}
