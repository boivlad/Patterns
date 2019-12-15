using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    abstract class Integral
    {
        public double Integrate(double a, double b, int n, Function function)
        {
            double step = (b - a) / n;
            double sum = 0;

            for(int i = 1; i <= n; ++i)
            {
                sum +=  SumMethod(a, i, step, function);
            }
            return step * sum;
        }

        public abstract double SumMethod(double a,  int i, double step, Function function);
    }
}
