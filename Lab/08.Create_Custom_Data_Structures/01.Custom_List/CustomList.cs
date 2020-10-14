using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace _01.Custom_List
{
    public class CustomList<T>
    {
        private T[] items;
        private int index;
        private const int InitialCapacity = 2;
        public int Count { get; private set; }

        public CustomList()
        {
            items = new T[InitialCapacity];
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return items[index];
                }
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    items[index] = value;
                }
            }
        }

        public void Add(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;

        }

        public void InsertAt(int index, T element)
        {
            CheckIfIndexIsInvalidAndThrowException(index);

            if (items.Length == Count)
            {
                Resize();
            }

            ShiftToRight(index);
            items[index] = element;
            Count++;
        }

        public T RemoveAt(int index)
        {
            CheckIfIndexIsInvalidAndThrowException(index);

            T element = items[index];
            items[index] = default;
            ShiftLeft(index);
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return element;
        }

        public void Swap(int fistIndex, int secondIndex)
        {
            CheckIfIndexIsInvalidAndThrowException(fistIndex);
            CheckIfIndexIsInvalidAndThrowException(secondIndex);

            T temp = items[fistIndex];
            items[fistIndex] = items[secondIndex];
            items[secondIndex] = temp;

        }

        public void Reverse()
        {
            T[] copy = new T[items.Length];
            int index = 0;

            for (int i = Count - 1; i >= 0; i--)
            {
                copy[index] = items[i];
                index++;
            }

            items = copy;
        }

        public int FindIndex(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        private void Shrink()
        {
            T[] copy = new T[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckIfIndexIsInvalidAndThrowException(int index)
        {
            if (index < 0 && index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return String.Join(" ", items); 
        }
    }
}
