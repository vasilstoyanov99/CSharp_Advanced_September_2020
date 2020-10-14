using System;
using System.Collections.Generic;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<double> scale = new EqualityScale<double>(5.55, 5.55);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
