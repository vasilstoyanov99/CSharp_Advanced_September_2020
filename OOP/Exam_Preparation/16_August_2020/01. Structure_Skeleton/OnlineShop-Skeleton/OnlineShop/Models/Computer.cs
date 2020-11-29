using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> _components;
        private List<IPeripheral> _peripherals;

        protected Computer
           (int id, string manufacturer, string model, decimal price, double overallPerformance)
           : base(id, manufacturer, model, price, overallPerformance)
        {
            _components = new List<IComponent>();
            _peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
        {
            get
            {
                return _components.AsReadOnly();
            }
        }

        public IReadOnlyCollection<IPeripheral> Peripherals
        {
            get
            {
                return _peripherals.AsReadOnly();
            }
        }

        public override double OverallPerformance
        {
            get
            {
                if (_components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + _components.Average(x => x.OverallPerformance);
            }
        }

        public override decimal Price
        {
            get
            {
                return base.Price + _components.Sum(x => x.Price) + _peripherals.Sum(x => x.Price);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (_components.Contains(component))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name,
                    GetType().Name
                    , Id));
            }

            _components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (_peripherals.Contains(peripheral))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name,
                    GetType().Name,
                    Id));
            }

            _peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (_components is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType,
                    GetType().Name, Id));
            }
            else if (_components.Any(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType,
                    GetType().Name, Id));
            }

            var toRemove = _components.FirstOrDefault(x => x.GetType().Name == componentType);
            _components.Remove(toRemove);
            return toRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (_peripherals is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    GetType().Name, Id));
            }
            else if (_peripherals.Any(x => x.GetType().Name != peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    GetType().Name, Id));
            }

            var toRemove = _peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            _peripherals.Remove(toRemove);
            return toRemove;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" Components ({Components.Count}):");

            foreach (var item in Components)
            {
                result.AppendLine(item.ToString());
            }

            double averagePerformance = 0.00;

            if (_peripherals.Count > 0)
            {
                averagePerformance = _peripherals.Average(x => x.OverallPerformance);
            }

            result.AppendLine($" Peripherals ({_peripherals.Count}); Average Overall Performance" +
                $" ({averagePerformance}):");

            foreach (var item in Peripherals)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
