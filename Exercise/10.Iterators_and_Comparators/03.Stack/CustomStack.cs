using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private T[] elements;
        private const int initialCapacity = 4;
        public int Count { get; private set; }
        public CustomStack()
        {
            elements = new T[initialCapacity];
        }

        public void Push(T element)
        {
            if (elements.Length == Count)
            {
                Resize();
            }

            elements[Count] = element;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }


            if (Count <= elements.Length / 4)
            {
                Shrink();
            }

            T lastElement = elements[Count - 1];
            elements[Count - 1] = default;
            Count--;
            return lastElement;
        }

        private void Resize()
        {
            T[] copy = new T[elements.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = elements[i];
            }

            elements = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[elements.Length / 4];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = elements[i];
            }

            elements = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
