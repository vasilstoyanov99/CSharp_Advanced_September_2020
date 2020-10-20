using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] items)
        {
            stones = items;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            for (int i = stones.Length - 1; i > 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
