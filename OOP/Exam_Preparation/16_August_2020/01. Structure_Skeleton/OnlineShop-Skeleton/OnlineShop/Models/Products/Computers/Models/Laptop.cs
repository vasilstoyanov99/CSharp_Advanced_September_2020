using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers.Models
{
    public class Laptop : Computer
    {
        private const int DEFAULT_OVERALL_PERFORMANCE = 10;

        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, DEFAULT_OVERALL_PERFORMANCE)
        {
        }
    }
}
