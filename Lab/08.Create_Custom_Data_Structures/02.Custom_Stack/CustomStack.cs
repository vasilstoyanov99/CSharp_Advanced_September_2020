using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Custom_Stack
{
   public class CustomStack<T>
    {
        private T[] items;
        private const int initialCapacity = 4;
        public int Count { get; private set; }
        public CustomStack()
        {
            items = new T[initialCapacity];
            Count = 0;
        }

        public void Push(T element)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            T lastElement = items[Count - 1];
            items[Count - 1] = default;
            Count--;
            return lastElement;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return items[Count - 1];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[items.Length / 4];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

    }
}
