using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    interface Subject
    {
        void calculate();
        void registerObserver(Car O);
        void removeObserver(Car O);
    }
}
