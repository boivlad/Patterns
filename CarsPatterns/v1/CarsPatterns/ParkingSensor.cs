using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class ParkingSensor:ParkingType
    {
        private string type;
        private float area;
        public ParkingSensor()
        {
            this.type = "С помощью парктроника";
            this.area = 4;
        }
        public float getArea()
        {
            return this.area;
        }

        public string getType()
        {
            return this.type;
        }
    }
}
