using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T, T2>
    {
        public T FirstItem { get; set; }
        public T2 SecondItem { get; set; }
        public Tuple(T firstItem, T2 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}"; 
        }
    }
}
