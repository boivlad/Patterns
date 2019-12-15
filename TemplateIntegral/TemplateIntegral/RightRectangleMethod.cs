using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    class RightRectangleMethod : Integral
    {
        public override double SumMethod(double a, int i, double step, Function function)
        {
            return function.valueAt(a + (i) * step);
        }

        public override string ToString()
        {
            return "'Метод правых треугольников':";
        }
    }
}
