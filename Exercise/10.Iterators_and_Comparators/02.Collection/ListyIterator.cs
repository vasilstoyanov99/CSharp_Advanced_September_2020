using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int internalIndex;

        public ListyIterator(List<T> elements)
        {
            list = elements;
            internalIndex = 0;
        }

        public bool Move()
        {
            if (internalIndex + 1 == list.Count)
            {
                return false;
            }
            else
            {
                internalIndex++;
                return true;
            }
        }

        public bool HasNext()
        {
            if (internalIndex + 1 == list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Print()
        {
            if (list == null)
            {
                throw new Exception("Invalid Operation!");
            }

            return list[internalIndex].ToString();
        }

        public string PrintAll()
        {
            if (list == null)
            {
                throw new Exception("Invalid Operation!");
            }

            StringBuilder result = new StringBuilder();

            foreach (T element in list)
            {
                result.Append(element + " ");
            }

            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in list)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
