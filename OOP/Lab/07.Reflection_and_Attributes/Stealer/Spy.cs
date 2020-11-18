using System;
using System.Collections.Generic;
using System.Linq;
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

        public string AnalyzeAcessModifiers(string className)
        {
            var classType = Type.GetType(className);
            FieldInfo[] classFileds = classType.GetFields(BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder result = new StringBuilder();

            foreach (var filed in classFileds)
            {
                result.AppendLine($"{filed.Name} must be private!");
            }

            foreach (var method in classNonPublicMethods.Where(n => n.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in classPublicMethods.Where(n => n.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }
    }
}
