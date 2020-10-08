using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Date_Modifier
{
    class DateModifier
    {
        public int daysDifference { get; set; }

        public void GetDaysDifference(DateTime startDate, DateTime endDate)
        {
            daysDifference = Math.Abs((startDate - endDate).Days);
        }
    }
}
