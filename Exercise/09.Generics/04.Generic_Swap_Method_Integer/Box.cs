using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Generic_Swap_Method_Integer
{
    public class Box<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
