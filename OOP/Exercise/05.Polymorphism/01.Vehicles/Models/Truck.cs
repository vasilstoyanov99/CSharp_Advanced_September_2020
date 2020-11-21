
namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double INCREASED_FUEL_CONSUMPTION_ARG = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + INCREASED_FUEL_CONSUMPTION_ARG;
    }
}
