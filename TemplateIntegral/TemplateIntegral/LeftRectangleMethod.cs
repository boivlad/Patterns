using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    class LeftRectangleMethod : Integral
    {
        public override double SumMethod(double a, int i, double step, Function function)
        {
            return function.valueAt(a + (i - 0.93482) * step);
        }

        public override string ToString()
        {
            return "'Метод левых треугольников':";
        }
    }
}
