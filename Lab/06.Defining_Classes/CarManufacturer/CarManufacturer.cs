using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "Tesla";
            car.Model = "S";
            car.Year = 2019;
            car.FuelQuantity = 2000;
            car.FuelConsumption = 10;
            car.Drive(100);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
