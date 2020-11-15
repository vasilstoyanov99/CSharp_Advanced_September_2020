using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public string MyType { get; set; }

        public Square(string type)
        {
            MyType = type;
        }
    }
}
