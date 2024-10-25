using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Implementations;
using Testing.Interfaces;

namespace Testing.Tests
{
    public class CalculatorPresenterImplTests
    {
        private readonly Mock<ICalculatorView> mockView;
        private readonly Mock<ICalculator> mockCalculator;
        private readonly CalculatorPresenterImpl presenter;

        public CalculatorPresenterImplTests()
        {
            mockView = new Mock<ICalculatorView>();
            mockCalculator = new Mock<ICalculator>();
            presenter = new CalculatorPresenterImpl(mockCalculator.Object, mockView.Object);
        }

        [Fact]
        public void OnPlusClicked_WhenCalled_PerformsAddition()
        {

            mockView.Setup(v => v.GetFirstArgumentAsString()).Returns("10");
            mockView.Setup(v => v.GetSecondArgumentAsString()).Returns("20");
            mockCalculator.Setup(c => c.Sum(10, 20)).Returns(30);

            presenter.OnPlusClicked();

            mockView.Verify(v => v.PrintResult(30), Times.Once);
        }

        [Fact]
        public void OnMinusClicked_WhenCalled_PerformsSubtraction()
        {

            mockView.Setup(v => v.GetFirstArgumentAsString()).Returns("20");
            mockView.Setup(v => v.GetSecondArgumentAsString()).Returns("10");
            mockCalculator.Setup(c => c.Subtract(20, 10)).Returns(10);

            presenter.OnMinusClicked();

            mockView.Verify(v => v.PrintResult(10), Times.Once);
        }

        [Fact]
        public void OnMultiplyClicked_WhenCalled_PerformsMultiplication()
        {
            mockView.Setup(v => v.GetFirstArgumentAsString()).Returns("10");
            mockView.Setup(v => v.GetSecondArgumentAsString()).Returns("5");
            mockCalculator.Setup(c => c.Multiply(10, 5)).Returns(50);

            presenter.OnMultiplyClicked();

            mockView.Verify(v => v.PrintResult(50), Times.Once);
        }

        [Fact]
        public void OnDivideClicked_WhenDivisorIsValid_PerformsDivision()
        {
            mockView.Setup(v => v.GetFirstArgumentAsString()).Returns("20");
            mockView.Setup(v => v.GetSecondArgumentAsString()).Returns("4");
            mockCalculator.Setup(c => c.Divide(20, 4)).Returns(5);

            presenter.OnDivideClicked();

            mockView.Verify(v => v.PrintResult(5), Times.Once);
        }

        [Fact]
        public void OnDivideClicked_WhenDividingByZero_DisplaysError()
        {
            mockView.Setup(v => v.GetFirstArgumentAsString()).Returns("20");
            mockView.Setup(v => v.GetSecondArgumentAsString()).Returns("0");
            mockCalculator.Setup(c => c.Divide(20, 0)).Throws(new ArithmeticException("Division by zero"));

            presenter.OnDivideClicked();

            mockView.Verify(v => v.DisplayError("Division by zero"), Times.Once);
        }

        [Fact]
        public void OnPlusClicked_WhenInputIsInvalid_DisplaysError()
        {
            mockView.Setup(v => v.GetFirstArgumentAsString()).Returns("abc");
            mockView.Setup(v => v.GetSecondArgumentAsString()).Returns("10");

            presenter.OnPlusClicked();

            mockView.Verify(v => v.DisplayError(It.IsAny<string>()), Times.Once);
        }
    }
}
