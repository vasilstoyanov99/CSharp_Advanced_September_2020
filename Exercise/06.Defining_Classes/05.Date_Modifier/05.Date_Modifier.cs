using System;
using System.Globalization;

namespace _05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();
            DateTime startDate = DateTime.Parse(dateOne);
            DateTime endDate = DateTime.Parse(dateTwo);
            DateModifier dateModifier = new DateModifier();
            dateModifier.GetDaysDifference(startDate, endDate);
            Console.WriteLine(dateModifier.daysDifference);
        }
    }
}
