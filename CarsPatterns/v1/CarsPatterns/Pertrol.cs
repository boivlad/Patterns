using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class Petrol : SpeedType
    {
        private string type;
        private float speed;

        public Petrol()
        {
            this.speed = 60;
            this.type = "Бензин";
        }
        public float getSpeed()
        {
            return this.speed;
        }
        public string getType()
        {
            return this.type;
        }
    }
}
