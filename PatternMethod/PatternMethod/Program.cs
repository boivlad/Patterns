using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3x^2+x+2
        }
        abstract class IntCalc
        {
            // Знает процедуру суммирования
            // В цикле h*f(i*x)
            public virtual void area();

        }
        class IntRectangle : IntCalc
        {
            public override void area()
            {

            }
        }
        class IntTrap : IntCalc
        {

        }
    }
}
