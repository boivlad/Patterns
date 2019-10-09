using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPatterns
{
    abstract class Car
    {
        public ParkingType parkingType;
        public SpeedType speedType;
        private float distance;

        public Car()
        {
            distance = 0;
        }
        public abstract string Name();
        public float getSpeed()
        {
            return speedType.getSpeed();
        }
        public void SpeedType()
        {
            Console.WriteLine(speedType.getType());
        }
        public float getArea()
        {
            return parkingType.getArea();
        }
        public string ParkingType()
        {
            return parkingType.getType();
        }
        public float addDistance()
        {
            return this.distance += speedType.getSpeed();
        }
        public float getDistance()
        {
            return this.distance;
        }
        public void setParkingType(ParkingType PT)
        {
            parkingType = PT;
        }
        public void info()
        {
            Console.WriteLine("Название автомобиля: {0}\n" +
                "-|Скорость: {1}км/ч\n" +
                "--|Стиль парковки: {2}\n" +
                "---|Пробег: {3}км\n" +
                "----|На парковке занято: {4}кв.м\n########################################", Name(), getSpeed(), ParkingType(), distance, getArea());
        }
    }
}
