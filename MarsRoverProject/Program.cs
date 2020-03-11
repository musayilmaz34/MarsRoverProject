using MarsRoverProject.Enums;
using MarsRoverProject.Manager;
using MarsRoverProject.Model;
using System;
using System.Linq;
using System.Text;

namespace MarsRoverProject
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var commandString = startCommandString();
            Console.WriteLine("Input:");
            Console.WriteLine(commandString);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Output:");
            ICommandManager commandManager = new CommandManager(commandString);
            commandManager.Execute();
            Console.Write(Environment.NewLine);
            Console.ReadLine();
        }


        private static string startCommandString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }
    }
}
