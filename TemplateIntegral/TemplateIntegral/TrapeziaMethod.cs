using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    class TrapeziaMethod : Integral
    {
        public override double SumMethod(double a, int i, double step, Function function)
        {
            return (function.valueAt(a + i * step) + function.valueAt(a + (i - 1) * step))/2;
        }

        public override string ToString()
        {
            return "'Метод трапеции':";
        }
    }
}
