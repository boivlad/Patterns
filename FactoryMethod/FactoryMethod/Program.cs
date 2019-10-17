using FactoryMethod.creators;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Клиент заказывает Телефон: ");
            Store xiaomi = new Phone();
            Console.Write(xiaomi.getProduct("Xiaomi").getName() + " - ");
            Console.WriteLine(xiaomi.getProduct("Xiaomi").getPrice() + "грн");

            Console.Write("Клиент заказывает Телефон: ");
            Store iphone = new Phone();
            Console.Write(iphone.getProduct("Iphone").getName() + " - ");
            Console.WriteLine(iphone.getProduct("Iphone").getPrice() + "грн");

            Console.Write("Клиент заказывает Ноутбук: ");
            Store xnotebook = new Notebook();
            Console.Write(xnotebook.getProduct("Xiaomi NoteBook").getName() + " - ");
            Console.WriteLine(xnotebook.getProduct("Xiaomi NoteBook").getPrice() + "грн");

            Console.Write("Клиент заказывает Ноутбук: ");
            Store macbook = new Notebook();
            Console.Write(macbook.getProduct("Apple MacBook").getName() + " - ");
            Console.WriteLine(macbook.getProduct("Apple MacBook").getPrice() + "грн");

            Console.ReadKey();
        }
    }
}