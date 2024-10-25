using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Interfaces
{
    public interface ICalculatorView
    {

        void PrintResult(double result);

        void DisplayError(string message);

        string GetFirstArgumentAsString();

        string GetSecondArgumentAsString();
    }

}
