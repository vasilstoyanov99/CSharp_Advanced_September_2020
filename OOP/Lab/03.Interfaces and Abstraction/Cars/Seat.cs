using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Seat warming process started");
            result.AppendLine("........");
            result.AppendLine($"Seat warmed successfully");
            return result.ToString();
        }

        public string Stop()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Seat warming process stopping");
            result.AppendLine("........");
            result.AppendLine($"Seat warming process stopped successfully");
            return result.ToString();
        }

        public override string ToString()
        {
            return $"Seat color: {Color}, Model: {Model}";
        }
    }
}
