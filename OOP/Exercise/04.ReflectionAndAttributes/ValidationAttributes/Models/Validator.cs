using System.Reflection;

using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();

            foreach (var property in propertyInfo)
            {
                var propertyCustomAttributes = property.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in propertyCustomAttributes)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
