using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public abstract class Beverage
    {
        String description = "Unknown Beverage";

        public String getDexsription()
        {
            return description;
        }
        public abstract double cost();
    }
}
