using System;

using _03.Shopping_Spree.Global;

namespace _03.Shopping_Spree.Models
{
    public static class Validators
    {
        public static void CheckValue(double value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format(Exception_Messages.NEGATIVE_VALUE_MSG, name));
            }
        }

        public static void CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Exception_Messages.EMPTY_NAME_MSG);
            }
        }
    }
}
