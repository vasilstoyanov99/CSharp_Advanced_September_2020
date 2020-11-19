using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsArray = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandArg = argsArray[0] + "Command";
            var assembly = Assembly.GetCallingAssembly();
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandArg);
            ICommand instance = (ICommand)Activator.CreateInstance(type);
            string result = instance.Execute(argsArray.Skip(1).ToArray());
            return result;
        }
    }
}
