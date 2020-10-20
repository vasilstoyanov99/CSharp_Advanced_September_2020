using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
    }
}
