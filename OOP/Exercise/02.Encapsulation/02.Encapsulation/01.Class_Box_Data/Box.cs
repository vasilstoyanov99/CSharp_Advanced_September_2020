using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Class_Box_Data
{
    public class Box
    {
        private const string EXCP_MSG = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                CheckSide(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                CheckSide(value, nameof(Width));
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                CheckSide(value, nameof(Height));
                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double CalculateTheSurfaceArea()
        {
            double result = (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
            return result;
        }

        public double CalculateTheLateralSurfaceArea()
        {
            double result = (2 * Length * Height) + (2 * Width * Height);
            return result;
        }

        public double CalculateTheVolume()
        {
            double result = Length * Width * Height;
            return result;
        }

        public void CheckSide(double side, string name)
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format(EXCP_MSG, name));
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Surface Area - {CalculateTheSurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {CalculateTheLateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {CalculateTheVolume():f2}");
            return result.ToString().Trim();
        }
    }
}
