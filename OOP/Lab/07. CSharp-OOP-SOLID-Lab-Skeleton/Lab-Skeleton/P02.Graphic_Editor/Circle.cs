﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        public string MyType { get; set; }

        public Circle(string type)
        {
            MyType = type;
        }
    }
}
