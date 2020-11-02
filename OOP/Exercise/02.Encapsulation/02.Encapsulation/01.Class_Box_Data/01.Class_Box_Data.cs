using System;

namespace _01.Class_Box_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box tryTo = new Box(length, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Box box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.CalculateTheSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateTheLateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.CalculateTheVolume():f2}");
        }
    }
}
