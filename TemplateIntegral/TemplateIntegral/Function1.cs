using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    class Function1: Function
    {
        protected override double function(double x)
        {
            return 3 * Math.Pow(x, 2) + x + 2;
        }// 3x^2+x+2

        public override string ToString()
        {
            return "3x^2 + x + 2";
        }
    }
}
