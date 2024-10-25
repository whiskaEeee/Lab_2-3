using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Interfaces
{
    public interface ICalculatorPresenter
    {
        void OnPlusClicked();

        void OnMinusClicked();

        void OnDivideClicked();

        void OnMultiplyClicked();
    }
}
