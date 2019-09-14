using System;

namespace Simulator
{
    public class CommandParser : ICommandParser
    {
        public IRobot Unit { get; protected set; }

        public CommandParser(IRobot r)
        {
            this.Unit = r;
        }

        public CommandType Parse(string command)
        {
            var splitCommand = command.Split(" ");
            if (!Enum.TryParse(splitCommand[0], true, out CommandType result))
                return CommandType.NOP;
            if (result != CommandType.PLACE && Unit.Face == Direction.NONE)
                return CommandType.NOP;
            if (result == CommandType.MOVE && ValidateMove())
                return result;
            if (result == CommandType.PLACE && splitCommand.Length == 2 && ParsePlaceParameters(splitCommand[1]))
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
            if (!ValidXY(xResult, yResult))
                return false;
            return true;
        }

        private bool ValidXY(int x, int y)
        {
            if (x < 0)
                return false;
            if (y < 0)
                return false;
            if (x > 5)
                return false;
            if (y > 5)
                return false;
            return true;
        }

        private bool ValidateMove()
        {
            var newX = Unit.X;
            var newY = Unit.Y;
            switch (Unit.Face)
            {
                case Direction.EAST:
                    ++newX;
                    break;
                case Direction.SOUTH:
                    --newY;
                    break;
                case Direction.WEST:
                    --newX;
                    break;
                case Direction.NORTH:
                    ++newY;
                    break;
            }
            return ValidXY(newX, newY);
        }
    }
}
