using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineShop.Models 
{
    public abstract class Component : Product, IComponent
    {
        public Component
            (int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation { get; protected set; }

        public ISite Site { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler Disposed;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append($" Generation: {Generation}");
            return result.ToString();
        }
    }
}
