using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomAnalyzer ra = new ProxyRandomAnalyzer();
            Random r = new Random();
            Console.WriteLine(ra.Period(r));
            Console.WriteLine(ra.Period(r));
            Console.WriteLine(ra.Period(new Random()));

            Console.ReadKey();
        }
    }
    interface RandomAnalyzer
    {
        int Period(Random r);
    }
    class RealRandomAnalyzer : RandomAnalyzer
    {
        public int Period(Random r)
        {
            Console.WriteLine("Real working");
            int k1 = r.Next(0, 1000000);
            int k2 = r.Next(0, 1000000);
            int c = 0;
            while (k2 != k1)
            {
                c++;
                k2 = r.Next(0, 1000000);
            }
            return c;
        }
    }
    class ProxyRandomAnalyzer : RandomAnalyzer
    {
        private RealRandomAnalyzer real;
        private List<Random> randoms;
        private List<int> periods;
        public ProxyRandomAnalyzer()
        {
            real = new RealRandomAnalyzer();
            randoms = new List<Random>();
            periods = new List<int>();
        }
        public int Period(Random r)
        {
            Console.WriteLine("Proxy working");

            if (randoms.Contains(r))
            {

                int p = randoms.IndexOf(r);
                return periods[p];
            }
            else
            {
                int p = real.Period(r);
                randoms.Add(r);
                periods.Add(p);
                return p;
            }
        }
    }

}
