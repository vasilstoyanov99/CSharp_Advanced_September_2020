using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int min;
        private int max;

        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("The age shoud be an integer!");
            }

            int ageArg = (int)(obj);
            return (ageArg >= min && ageArg <= max);
        }
    }
}
