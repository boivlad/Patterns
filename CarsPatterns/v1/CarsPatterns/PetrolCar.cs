using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class PetrolCar : Car
    {
        private string name;

        public PetrolCar(string name)
        {
            this.name = name;
            speedType = new Petrol();
            parkingType = new Ram();
        }
        public override string Name()
        {
            return name;
        }
    }
}
