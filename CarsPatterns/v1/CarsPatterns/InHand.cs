using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class InHand:ParkingType
    {
        private string type;
        private float area;
        public InHand()
        {
            this.type = "Вручную";
            this.area = 6;
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
