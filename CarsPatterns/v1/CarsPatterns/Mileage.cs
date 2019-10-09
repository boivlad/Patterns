using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class Mileage : Subject
    {
        private float mileage;

        private List<Car> Cars = new List<Car>();
        public Mileage (float mileage = 1000)
        {
            this.mileage = mileage;
        }
        public void registerObserver(Car C)
        {
            Cars.Add(C);
        }
        public void removeObserver(Car C)
        {
            Cars.Remove(C);
        }
        public void calculate()
        {
            
            bool flag = true;
            while (flag)
            {
                foreach (Car C in Cars)
                {
                    C.addDistance();
                    if (C.getDistance() >= this.mileage)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (!flag)
            {
                foreach (Car C in Cars)
                {
                    C.info();
                }
               
            }
        }
    }
}
