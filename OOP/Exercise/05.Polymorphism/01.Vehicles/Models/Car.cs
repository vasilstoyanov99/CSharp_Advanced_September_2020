
namespace _01.Vehicles.Models
{
    public class Car : Vehicle 
    {
        private double INCREASED_FUEL_CONSUMPTION_ARG = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + INCREASED_FUEL_CONSUMPTION_ARG; 
    }
}
