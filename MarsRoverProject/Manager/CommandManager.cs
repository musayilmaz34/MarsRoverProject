using MarsRoverProject.Enums;
using MarsRoverProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRoverProject.Manager
{
    public class CommandManager : ICommandManager
    {
        private string CommandString;
        private IDictionary<string, CommandType> commandTypeDictionary;

        public CommandManager(string _CommandString)
        {
            InitializeCommandTypeDictionary();
            CommandString = _CommandString;
        }

        public CommandType GetCommandType(string command)
        {
            try
            {
                var commandType = commandTypeDictionary.First(
                    regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(command));

                return commandType.Value;
            }
            catch (InvalidOperationException e)
            {
                var exceptionMessage = String.Format("String '{0}' is not a valid command", command);
                throw new Exception(exceptionMessage, e);
            }
        }

        public void Execute()
        {
            var commands = CommandString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int maxX = 0;
            int maxY = 0;
            int X = 0;
            int Y = 0;
            string direction = "";

            foreach (var command in commands)
            {
                var commandType = GetCommandType(command);

                switch (commandType)
                {
                    case CommandType.LandingSurfaceSizeCommand:
                        var argumentPlato = command.Split(' ');
                        maxX = int.Parse(argumentPlato[0]);
                        maxY = int.Parse(argumentPlato[1]);
                        break;
                    case CommandType.RoverDeployCommand:
                        var argumentRover = command.Split(' ');
                        X = int.Parse(argumentRover[0]);
                        Y = int.Parse(argumentRover[1]);
                        direction = argumentRover[2];
                        break;
                    case CommandType.RoverExploreCommand:
                        Position position = new Position(X, Y, maxX, maxY, (Directions)Enum.Parse(typeof(Directions), direction.ToString()));
                        IVehicle rover = new Rover(new MoveManager(), position);
                        rover.StartMoving(command);
                        break;
                    default:
                        break;
                }
            }
        }

        private void InitializeCommandTypeDictionary()
        {
            commandTypeDictionary = new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.LandingSurfaceSizeCommand },
                { @"^\d+ \d+ [NSEW]$", CommandType.RoverDeployCommand },
                { @"^[LRM]+$", CommandType.RoverExploreCommand }
            };
        }
    }
}
