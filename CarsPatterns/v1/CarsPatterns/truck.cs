using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class Truck:SpeedType
    {
        private string type;
        private float speed;

        public Truck()
        {
            this.speed = 20;
            this.type = "Эвакуатор";
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
