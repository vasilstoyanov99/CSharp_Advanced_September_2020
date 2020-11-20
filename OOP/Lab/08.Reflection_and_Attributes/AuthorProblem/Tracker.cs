using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.Static);

            foreach (var method in classMethods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var customAttributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in customAttributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}"); 
                    }
                }
            }
        }
    }
}
