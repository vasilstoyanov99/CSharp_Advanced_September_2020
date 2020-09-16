using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFoodAvailable = int.Parse(Console.ReadLine());
            var ordersQuantity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int theBiggestOrder = ordersQuantity.Max();
            Console.WriteLine(theBiggestOrder);

            if (ordersQuantity.Count > 0)
            {

                while (ordersQuantity.Count > 0)
                {
                    int orderToPop = ordersQuantity.Peek();
                    
                    if (orderToPop <= quantityOfFoodAvailable)
                    {
                        quantityOfFoodAvailable -= ordersQuantity.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }

                if (ordersQuantity.Count <= 0)
                {
                    Console.WriteLine("Orders complete");
                }
                else
                {
                    Console.WriteLine($"Orders left: " + String.Join(" ", ordersQuantity));
                }
            }
        }
    }
}
