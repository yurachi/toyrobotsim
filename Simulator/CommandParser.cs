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
            var result = CommandType.NOP;
            if (!Enum.TryParse(splitCommand[0], true, out result)) return CommandType.NOP;
            return result;
        }

    }
}
