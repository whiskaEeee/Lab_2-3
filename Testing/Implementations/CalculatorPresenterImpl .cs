using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Interfaces;

namespace Testing.Implementations
{
    public class CalculatorPresenterImpl : ICalculatorPresenter
    {
        private readonly ICalculator calculator;
        private readonly ICalculatorView view;

        public CalculatorPresenterImpl(ICalculator calculator, ICalculatorView view)
        {
            this.calculator = calculator;
            this.view = view;
        }

        public void OnPlusClicked()
        {
            TryCalculate((a, b) => calculator.Sum(a, b));
        }

        public void OnMinusClicked()
        {
            TryCalculate((a, b) => calculator.Subtract(a, b));
        }

        public void OnDivideClicked()
        {
            TryCalculate((a, b) =>
            {
                try
                {
                    return calculator.Divide(a, b);
                }
                catch (ArithmeticException e)
                {
                    view.DisplayError(e.Message);
                    return double.NaN;
                }
            });
        }


        public void OnMultiplyClicked()
        {
            TryCalculate((a, b) => calculator.Multiply(a, b));
        }

        private void TryCalculate(Func<double, double, double> operation)
        {
            try
            {
                double firstArg = double.Parse(view.GetFirstArgumentAsString());
                double secondArg = double.Parse(view.GetSecondArgumentAsString());
                double result = operation(firstArg, secondArg);
                view.PrintResult(result);
            }
            catch (FormatException)
            {
                view.DisplayError("Invalid input. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                view.DisplayError(ex.Message);
            }
        }
    }
}
