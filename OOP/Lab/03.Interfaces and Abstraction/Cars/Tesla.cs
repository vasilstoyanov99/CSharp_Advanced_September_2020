using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : IElectricCar
    {
        public Tesla(int battery, string model, string color)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }
        
        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine();
            result.AppendLine("Starting engine");
            result.AppendLine("........");
            result.AppendLine($"Engine started successfully on model {Model} with color: {Color}");
            return result.ToString();
        }

        public string Stop()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Stopping engine");
            result.AppendLine("........");
            result.AppendLine($"Engine stopped successfully on model {Model} with color: {Color}");
            return result.ToString();
        }

        public override string ToString()
        {
            return $"{Color} Tesla Model {Model} with {Battery} Batteries";
        }
    }
}
