using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public string MyType { get; set; }

        public Rectangle(string type)
        {
            MyType = type;
        }
    }
}
