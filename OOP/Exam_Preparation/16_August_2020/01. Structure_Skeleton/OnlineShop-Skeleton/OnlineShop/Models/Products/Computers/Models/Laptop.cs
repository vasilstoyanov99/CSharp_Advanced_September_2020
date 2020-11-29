using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public class Laptop : Computer
    {
        private const int DEF_OVERALL_PERFORMANCE = 10;

        protected Laptop
           (int id, string manufacturer, string model, decimal price, double overallPerformance)
           : base(id, manufacturer, model, price, overallPerformance)
        {

        }

        public override double OverallPerformance
                 => base.OverallPerformance * DEF_OVERALL_PERFORMANCE;
    }
}
