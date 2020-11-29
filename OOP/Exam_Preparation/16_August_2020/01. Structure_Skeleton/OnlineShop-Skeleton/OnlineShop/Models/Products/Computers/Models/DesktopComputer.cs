using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public class DesktopComputer : Computer
    {
        private const int DEF_OVERALL_PERFORMANCE = 15;

        public DesktopComputer
           (int id, string manufacturer, string model, decimal price, double overallPerformance)
           : base(id, manufacturer, model, price, overallPerformance)
        {

        }

        public override double OverallPerformance
                 => base.OverallPerformance * DEF_OVERALL_PERFORMANCE;
    }
}
