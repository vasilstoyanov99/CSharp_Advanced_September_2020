using System;

namespace _GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] money = ArrayCreator.Create(10, "$$$");
            int[] repeat = ArrayCreator.Create(5, 15);
            Console.WriteLine(String.Join(", ", money));
            Console.WriteLine(String.Join(", ", repeat));
        }
    }
}
