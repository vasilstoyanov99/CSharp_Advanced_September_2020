using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Peripheral : Product, IPeripheral
    {
        public Peripheral
            (int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectionType;
        }

        public string ConnectionType { get; protected set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append($" Connection Type: {ConnectionType}");
            return result.ToString();
        }
    }
}
