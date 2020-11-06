using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double height, double width)
        {
            this.length = height;
            this.width = width;
        }
        public override double CalculateArea()
        {
            return length * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (length + width);
        }

        public override string Draw()
        {
            StringBuilder result = new StringBuilder();
            DrawLine(this.width, '*', '*', result);
            for (int i = 1; i < this.length - 1; ++i)
                DrawLine(this.width, '*', ' ', result);
            DrawLine(this.width, '*', '*', result);
            return result.ToString();
        }

        private void DrawLine(double width, char end, char mid, StringBuilder result)
        {
            result.Append(end);
            for (int i = 1; i < width - 1; ++i)
                result.Append(mid);
            result.AppendLine(end.ToString());
        }
    }
}
