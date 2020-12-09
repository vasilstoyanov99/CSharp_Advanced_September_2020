using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Components.Models;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Computers.Models;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Peripherals.Models;

namespace OnlineShop.Core.Models
{
    partial class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!Enum.IsDefined(typeof(ComputerType), computerType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = null;

            switch (computerType)
            {
                case "DesktopComputer":
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case "Laptop":
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (!Enum.IsDefined(typeof(PeripheralType), peripheralType))
            {
                
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);
            computers.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);
            IPeripheral peripheral = peripherals.
                FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer,
            string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (!Enum.IsDefined(typeof(ComponentType), componentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            components.Add(component);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);
            computers.FirstOrDefault(x => x.Id == computerId).RemoveComponent(componentType);
            IComponent component = components.FirstOrDefault(x =>
                x.GetType().Name == componentType);
            components.Remove(component);
            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer computer = CheckIfComputerExists(id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count == 0 || computers.Any(x => x.Price > budget))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer theBestComputer =
                computers
                    .Where(x => x.Price <= budget)
                    .OrderByDescending(x => x.OverallPerformance)
                    .FirstOrDefault();
            computers.Remove(theBestComputer);
            return theBestComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = CheckIfComputerExists(id);
            return computer.ToString();
        }

        private IComputer CheckIfComputerExists(int id)
        {
            IComputer foundComputer = computers.FirstOrDefault(x => x.Id == id);

            if (foundComputer is null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return foundComputer;
        }
    }
}
