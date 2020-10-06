using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3),
            };

            var engine = new Engine(420, 69);

            Car car = new Car("Tesla", "3", 2019, 2000, 50, engine, tires);
        }
    }
}
