
namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double INCREASED_FUEL_CONSUMPTION_ARG = 1.6;
        private double TANK_FUEL_LOSS = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + INCREASED_FUEL_CONSUMPTION_ARG;

        public override void Refuel(double amount)
        {
            base.Refuel(amount * TANK_FUEL_LOSS);
        }
    }
}
