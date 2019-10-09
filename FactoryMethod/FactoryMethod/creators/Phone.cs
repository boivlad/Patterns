using FactoryMethod.products;
using System;

namespace FactoryMethod.creators
{
    class Phone : Store
    {
        public override Product getProduct(string Name)
        {
            if (Name == "Iphone")
            {
                return new Iphone();
            }
            if (Name == "Xiaomi")
            {
                return new Xiaomi();
            }
            return new Xiaomi();

        }
    }
}
