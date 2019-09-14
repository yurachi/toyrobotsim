using System;

namespace Simulator
{
    public class CommandParser
    {
        public CommandParser()
        {

        }

        public CommandType Parse(string command)
        {
            var splitCommand = command.Split(" ");
            if (!Enum.TryParse(splitCommand[0], true, out CommandType result))
                return CommandType.NOP;
            if (result != CommandType.PLACE)
                return result;
            if (splitCommand.Length == 2 && ParsePlaceParameters(splitCommand[1]))
                return result;
            return CommandType.NOP;
        }

        private bool ParsePlaceParameters(string parameters)
        {
            var splitParameters = parameters.Split(",");
            if (splitParameters.Length != 3)
                return false;
            if (!int.TryParse(splitParameters[0], out int xResult))
                return false;
            if (!int.TryParse(splitParameters[1], out int yResult))
                return false;
            if (!Enum.TryParse(splitParameters[2], out Direction dResult))
                return false;
            return true;
        }
    }
}
