using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class Ram:ParkingType
    {
        private string type;
        private float area;
        public Ram()
        {
            this.type = "'Как баран'";
            this.area = 10;
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
