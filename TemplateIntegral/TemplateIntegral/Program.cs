using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateIntegral
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1, b = 2; 
            int n = 20;

            Function f = new Function1();

            Integral i = new LeftRectangleMethod();
            PrintIntegral(a, b, n, f, i);

            i = new RightRectangleMethod();
            PrintIntegral(a, b, n, f, i);

            i = new TrapeziaMethod();
            PrintIntegral(a, b, n, f, i);

            i = new MidRectangleMethod();
            PrintIntegral(a, b, n, f, i);

            Console.ReadKey();
        }

        static void PrintIntegral(double a, double b, int n, Function f, Integral i)
        {
            Console.WriteLine(i.ToString() + " Интеграл функции " + f.ToString() + ": " + i.Integrate(a, b, n, f));
        }
    }
}
