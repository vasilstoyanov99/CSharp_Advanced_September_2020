﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack;
        public int Count { get; }

        public Box()
        {
            stack = new Stack<T>();
        }
        public void Add(T element)
        {
            stack.Push(element);
        }

        public T Remove()
        {
           return stack.Pop();
        }
    }
}
