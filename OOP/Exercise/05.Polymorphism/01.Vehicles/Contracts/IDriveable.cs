
namespace _01.Vehicles.Contracts
{
    public interface IDriveable
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public int TankCapacity { get; }

        string Drive(double amount);

        void Refuel(double amount, double lossPercentage);
    }
}
