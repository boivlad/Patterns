using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Mileage mileage = new Mileage(1000);
            Car Tesla = new ElectricityCar("Tesla");
            Car Mitsubishi = new PetrolCar("Grandis");
            Car Tayota = new PetrolCar("Carola");
            Car BMW = new BrokenCar("X5");
            mileage.registerObserver(Tesla);
            mileage.registerObserver(Mitsubishi);
            mileage.registerObserver(BMW);
            mileage.registerObserver(Tayota);
            mileage.calculate();
            Console.ReadKey();
        }
    }
}
