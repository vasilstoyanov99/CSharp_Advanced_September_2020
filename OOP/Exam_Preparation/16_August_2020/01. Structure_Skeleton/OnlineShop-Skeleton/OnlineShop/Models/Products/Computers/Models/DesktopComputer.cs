using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers.Models
{
    public class DesktopComputer : Computer
    {
        private const int DEFAULT_OVERALL_PERFORMANCE = 15;

        public DesktopComputer(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, DEFAULT_OVERALL_PERFORMANCE)
        {
        }
    }
}
