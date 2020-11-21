
namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void IncreaseFuelConsumption()
        {
            base.IncreaseFuelConsumption();
        }

        public override void BringDefaultFuelConsumption()
        {
            base.BringDefaultFuelConsumption(); 
        }
    }
}
