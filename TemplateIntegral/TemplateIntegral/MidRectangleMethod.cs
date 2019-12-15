using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    class MidRectangleMethod: Integral
    {
        public override double SumMethod(double a, int i, double step, Function function)
        {
            return function.valueAt(a + (i - 0.5) * step);
        }

        public override string ToString()
        {
            return "'Метод средних прямоугольников':";
        }
    }
}
