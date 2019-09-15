using System;

namespace Simulator
{
    public class Executor : IExecutor
    {
        public IRobot Unit { get; protected set; }

        public Action<string> WriteLine { get; set; }

        public Executor(IRobot r)
        {
            this.Unit = r;
            this.WriteLine = Console.WriteLine;
        }

        public void Execute(CommandType command, int x = -1, int y = -1, Direction d = Direction.NONE)
        {
            switch (command)
            {
                case CommandType.PLACE:
                    Unit.X = x;
                    Unit.Y = y;
                    Unit.FacingDirection = d;
                    break;

                case CommandType.MOVE:
                    var newX = Unit.X;
                    var newY = Unit.Y;
                    Calculator.CalculateMove(ref newX, ref newY, Unit.FacingDirection);
                    Unit.X = newX;
                    Unit.Y = newY;
                    break;

                case CommandType.LEFT:
                    var newDirection = Unit.FacingDirection;
                    Calculator.CalculateTurn(ref newDirection, CommandType.LEFT);
                    Unit.FacingDirection = newDirection;
                    break;

                case CommandType.RIGHT:
                    newDirection = Unit.FacingDirection;
                    Calculator.CalculateTurn(ref newDirection, CommandType.RIGHT);
                    Unit.FacingDirection = newDirection;
                    break;

                case CommandType.REPORT:
                    this.WriteLine($"{Unit.X},{Unit.Y},{Unit.FacingDirection}");
                    break;
            }
        }
    }
}
