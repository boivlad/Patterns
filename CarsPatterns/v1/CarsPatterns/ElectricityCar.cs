using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class ElectricityCar : Car
    {
        private string name;

        public ElectricityCar(string name)
        {
            this.name = name;
            speedType = new Electricity();
            parkingType = new ParkingSensor();
        }
        public override string Name()
        {
            return name;
        }
    }
}
