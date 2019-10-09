using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class BrokenCar : Car
    {
        private string name;

        public BrokenCar(string name)
        {
            this.name = name;
            speedType = new Truck();
            parkingType = new InHand();
        }
        public override string Name()
        {
            return name;
        }
    }
}
