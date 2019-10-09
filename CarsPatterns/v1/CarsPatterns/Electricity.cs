using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class Electricity:SpeedType
    {
        private string type;
        private float speed;

        public Electricity()
        {
            this.speed = 50;
            this.type = "Електричество";
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
