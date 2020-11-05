using System;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Comfy 3000", "Space Black");
            ICar tesla = new Tesla(50000, "3", "Red");
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());
            Console.WriteLine(seat);
            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());
            Console.WriteLine(tesla);
        }
    }
}
