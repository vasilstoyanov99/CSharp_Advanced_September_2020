using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T, T2, T3>
    {
        public T FirstItem { get; set; }
        public T2 SecondItem { get; set; }
        public T3 ThirdItem { get; set; }

        public Threeuple(T fisrtItem, T2 secondItem, T3 thirdItem)
        {
            FirstItem = fisrtItem;
            SecondItem = secondItem;
            ThirdItem = thirdItem;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
