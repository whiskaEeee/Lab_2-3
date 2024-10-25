namespace Calc_UI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Testing.Implementations;
    using Testing.Interfaces;

    public class CalculatorController : Controller
    {
        private readonly ICalculator calculator;
        private readonly ICalculatorView view;

        public CalculatorController(ICalculator calculator, ICalculatorView view)
        {
            this.calculator = calculator;
            this.view = view;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string operation, string firstNumber, string secondNumber)
        {
            try
            {
                double a = Convert.ToDouble(firstNumber);
                double b = Convert.ToDouble(secondNumber);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = calculator.Sum(a, b);
                        break;
                    case "-":
                        result = calculator.Subtract(a, b);
                        break;
                    case "*":
                        result = calculator.Multiply(a, b);
                        break;
                    case "/":
                        result = calculator.Divide(a, b);
                        break;
                }

                ViewBag.Result = result;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("Index");
        }
    }

}
