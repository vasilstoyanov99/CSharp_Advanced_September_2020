using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException
                (String.Format
                    (ExceptionMessages.ExistingComponent, component.GetType().Name, base.GetType().Name, Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = components.FirstOrDefault
                (x => x.GetType().Name == componentType);

            if (component is null)
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.NotExistingComponent, componentType, base.GetType().Name, Id));
            }

            components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException
                (String.Format
                    (ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, base.GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = peripherals.FirstOrDefault
                (x => x.GetType().Name == peripheralType);

            if (peripheral is null)
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.NotExistingPeripheral, peripheralType, base.GetType().Name, Id));
            }

            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + components.Average
                        (x => x.OverallPerformance);
                }
            }
        }

        public override decimal Price => base.Price + components.Sum(x => x.Price)
                                                    + peripherals.Sum(x => x.Price);

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" Components ({Components.Count}):");

            if (components.Count > 0)
            {
                foreach (var item in components)
                {
                    result.AppendLine($"  {item.ToString()}");
                }
            }

            result.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(x => x.OverallPerformance)}):");

            if (peripherals.Count > 0)
            {
                foreach (var item in peripherals)
                {
                    result.AppendLine($"  {item.ToString()}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
