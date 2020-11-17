using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] filedsNames)
        {
            var classType = Type.GetType(className);
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            var result = new StringBuilder();
            result.AppendLine($"Class under investigation: {className}");

            foreach (var filedName in filedsNames)
            {
                var fieldInfo = classType.GetField(filedName, 
                    BindingFlags.Public
                    | BindingFlags.NonPublic 
                    | BindingFlags.Instance 
                    | BindingFlags.Static 
                    | BindingFlags.Instance);
                result.AppendLine($"{filedName} = {fieldInfo.GetValue(classInstance)}");
            }

           return result.ToString().TrimEnd();
        }
    }
}
